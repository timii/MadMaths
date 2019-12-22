using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;
using MadMaths.calculations;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace MadMaths
{
    /// <summary>
    /// Diese Klasse sorgt für den Datenaustausch zwischen den einzelnen Pages sowie
    /// zwischen den Komponenten innerhalb der Pages
    /// </summary>
    static internal class Controller
    {
        internal static string currentGrade; // enthält den Namen der aktuell ausgewählten Stufe (z.B. Grundschule)
        internal static string currentTheme; // enthält den Namen des aktuellen Themas (z.B. Addieren)
        internal static string currentExercise; // enthält den genauen Namen der aktuellen Aufgabe (z.B. Addieren I)
        internal static bool UserIsLoggedIn = false;
        internal static bool UserIsOnline = false;
        private static readonly string UserSaveDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ".madmaths/");
        private static readonly string UserSaveFile = Path.Combine(UserSaveDir, "user.json");
        private static readonly string LocalRanklist = Path.Combine(UserSaveDir, "ranklist.json");
        internal static User user;           // das user Objekt, welches alle Daten des Benutzers zur Laufzeit enthält
        internal static List<UserRank> ranklist;

        internal static Dictionary<string, IStufe> Stufen = new Dictionary<string, IStufe>()
        {
            {"Grundschule",new Grundschule() },
            {"Mittelstufe", new Mittelstufe() },
            {"Oberstufe", new Oberstufe() }
        };

        static Controller()
        {
            // Initialisierung
            if (!CheckSaveDir()) CreateSaveDir();
            if (!CheckSaveFile()) CreateUserJS();

            user = new User();
            if (ReadUserJS(out string userjson))
            {
                user = JsonConvert.DeserializeObject<User>(userjson); // die daten werden im User Objekt gespeichert
            }
            if (!Client.LoginUser())
            {
                new CustomMB("Falscher Benutzername oder Passwort").ShowDialog();
            }
        }

        internal static BitmapImage LoadImage(in byte[] imageData)    // Code von https://bit.ly/2YFCn3E
        // nimmt das Bild als bytes an und wandelt es zu BitmapImage um
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new System.IO.MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        private static bool CheckSaveDir()           // überprüft, ob der .madmaths Ordner vorhanden ist
        {
            return Directory.Exists(UserSaveDir);
        }

        private static bool CheckSaveFile()          // überprüft, ob die user.json vorhanden ist
        {
            return File.Exists(UserSaveFile);
        }

        private static void CreateSaveDir()
        {
            DirectoryInfo di = Directory.CreateDirectory(UserSaveDir);
            di.Attributes = FileAttributes.Directory | FileAttributes.Hidden; // erstellt einen versteckten Ordner
            CreateUserJS();
        }

        private static void CreateUserJS()           // erstellt die user.json
        {
            using (File.Create(UserSaveFile)) { };
        }

        private static bool ReadUserJS(out string UserJson)
        {
            FileInfo fi = new FileInfo(UserSaveFile);
            fi.Attributes = FileAttributes.Normal;
            using (StreamReader sr = new StreamReader(UserSaveFile))
            {
                UserJson = sr.ReadToEnd();          // liest die user.json als string ein
            }
            fi.Attributes = FileAttributes.ReadOnly | FileAttributes.Hidden;
            if (UserJson.Length > 0) { return true; }
            else { return false; }
        }

        internal static void UpdateUserJson()
        {
            FileInfo fi = new FileInfo(UserSaveFile);
            fi.Attributes = FileAttributes.Normal;
            using (StreamWriter file = new StreamWriter(UserSaveFile, false))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, user);                  // speichert das User objekt als user.json
            }
            fi.Attributes = FileAttributes.ReadOnly | FileAttributes.Hidden;
        }

        internal static void UpdateAvatarImg(in BinaryReader img, in long fileLength)
        {
            user.avatarImg = System.Convert.ToBase64String(img.ReadBytes((int)fileLength));
            UpdateUserJson();
            Task.Run(() => Client.UpdateAvatar());
        }

        internal static void UpdateLevel(in float multiplier=1)
        {
            int exp = Convert.ToInt32(CalcLevel() * multiplier);
            var maxEXP = user.level * 100;
            if (user.level < 99) user.currentProgress += exp;
            if (user.currentProgress >= maxEXP && user.level < 99)
            {
                ++user.level;
                user.currentProgress -= maxEXP;
                LevelUpWindow lvlup = new LevelUpWindow(user.level.ToString());
                lvlup.Owner = System.Windows.Application.Current.MainWindow;
                Task.Run(() => Client.UpdateUserData("LEVEL"));
                lvlup.ShowDialog();
            }
        }

        private static int CalcLevel()
        {
            switch (currentTheme)
            {
                case "Zeitaufgaben" : return 5;
                case "Textaufgaben II": 
                case "Gleichungssysteme2x2": 
                case "Quadratische Gleichungen": 
                case "Logarithmen": 
                case "Integralregeln":
                case "Symmetrie":
                case "Extrempunkte":
                case "Nullstellen":
                case "Wendepunkte": return 15;
                case "Hypergeometrische Verteilung": case "Ableiten": case "Integral": return 20;
                case "Ableiten II": case "Integral II":  return 25;
                default: return 10;
            }
        }

        internal static void FillLastSessions()
        {
            if (user.lastSessions.Count == 5) user.lastSessions.Dequeue();
            user.lastSessions.Enqueue(currentGrade + ':' + currentTheme);
            UpdateUserJson();
        }

        internal static async Task CreateRankList()
        {
            ranklist = new List<UserRank>();
            string stringjson;
            if (UserIsOnline)
            {
                stringjson = await Task.Run<string>(() => Client.GetRanklist());
                await Task.Run(() => SaveRanklistLocal(stringjson));
            }
            else
            {
                stringjson = LoadRanklistLocal();
            }
            if (stringjson.Length > 0)
            {
                int rank = 1;
                var rawjson = JObject.Parse(stringjson);
                foreach (var item in rawjson)
                {
                    ranklist.Add(new UserRank()
                    {
                        UserName = item.Key,
                        Points = Int32.Parse(item.Value["Points"].ToString()),
                        avatarImg = LoadImage(Convert.FromBase64String(item.Value["avatarImg"].ToString())),
                        rank = rank++
                    });
                }
                for (int i = 0; i < ranklist.Count; i++)
                {
                    switch (i)
                    {
                        case 0: ranklist[i].RankColor = "Orange"; break;
                        case 1: ranklist[i].RankColor = "#FFFDB83B"; break;
                        case 2: ranklist[i].RankColor = "#FFFDC560"; break;
                    }
                }
            }
        }

        private static void SaveRanklistLocal(in string RanklistString)
        {
            using (StreamWriter file = new StreamWriter(LocalRanklist, false))
            {
                file.Write(RanklistString);
            }
        }
        private static string LoadRanklistLocal()
        {
            if (File.Exists(LocalRanklist))
            {
                string RanklistString;
                using (StreamReader file = new StreamReader(LocalRanklist))
                {
                    RanklistString = file.ReadToEnd();
                }
                return RanklistString;
            }
            return "";
        }

        internal static void UpdateChallengeData()
        {
            switch (currentGrade)
            {
                case "Grundschule": ++user.grundschule; break;
                case "Mittelstufe": ++user.mittelstufe; break;
                case "Oberstufe": ++user.oberstufe; break;
            }
        }
    }

    internal static class Client
    {
        internal static TcpClient client;
        static NetworkStream stream;
        static byte[] buffer;
        static Client()
        {
            try
            {
                // client = new TcpClient("127.0.0.1", 7777);
                // client = new TcpClient("45.88.108.218", 7777);
                client = new TcpClient("uselesscode.works", 7777);
                stream = client.GetStream();
                buffer = new byte[1024];
                if (CheckConnection())
                {
                    Controller.UserIsOnline = true;
                }
                else { throw new SocketException(); }
            }
            catch (SocketException) {} 
        }
        /// <summary>
        /// Ein Workaround für ein Verbindungsproblem, welches während des Testens aufgetreten ist
        /// </summary>
        /// <returns>Gibt true zurück, wenn die Verbindung erfolgreich hergestellt wurde, false andernfalls</returns>
        static private bool CheckConnection()
        {
            try
            {
                if (recv() == "connected") { return true; }
            }
            catch (Exception)
            {
                for (int i = 0; i < 200; i++)
                {
                    try
                    {
                        client.Connect("uselesscode.works", 7777);
                        // client.Connect("127.0.0.1", 7777);
                        stream = client.GetStream();
                        if (recv() == "connected") { return true; }
                    }
                    catch (Exception) { }
                }
            }
            return false;
        }

        static internal string RegisterUser(in string username, in string usrpwd)
        {
            if (Controller.UserIsOnline)
            {
                string msg = string.Format("REGISTERUSER_{0}_{1}", username, usrpwd);
                send(msg);
                return recv();
            }
            return null;
        }

        static internal bool LoginUser(in string username, in string pw)
        {
            if (Controller.UserIsOnline && username != null && pw != null)
            {
                string msg = string.Format("LOGINUSER_{0}_{1}", username, pw);
                send(msg);
                if (recv() == "success")
                {
                    Controller.UserIsLoggedIn = true;
                    return true;
                }
                Controller.user.UserName = null;
                return false;
            }
            return true;
        }

        static internal bool LoginUser()
        {
            return LoginUser(Controller.user.UserName, Controller.user.password);
        }

        static internal void LogoutUser()
        {
            send("LOGOUTUSER");
        }

        static internal bool CheckUsername(in string username)
        {
            if (Controller.UserIsOnline)
            {
                string msg = string.Format("CHECKUSERNAME_{0}", username);
                send(msg);
                if (recv() == "success")
                { return true; }
                return false;
            }
            return true;
        }

        static internal void UpdateAvatar()
        {
            string msg = "UPDATEAVATARIMG";
            send(msg);
            send(Controller.user.avatarImg);
            send("ENDIMGSTREAM");
        }

        static internal void UpdateUserData(in string cmd)
        {
            if (Controller.UserIsLoggedIn)
            {
                string msg = string.Format("UPDATEUSERDATA_{0}_{1}_{2}", cmd, Controller.user.level, Controller.user.currentProgress);
                send(msg);
            }
        }

        static internal string GetRanklist()
        {
            if (Controller.UserIsOnline)
            {
                string msg = "GETRANKLIST";
                send(msg);
                return recv();
            }
            return null;
        }

        static internal async Task GetUserData()
        {
            send("GETUSERDATA");
            var rawdata = await Task.Run(() => recv());
            var userdata = JObject.Parse(rawdata);
            Controller.user.level = (int)userdata["level"].ToObject(typeof(int));
            Controller.user.currentProgress = (int)userdata["currentProgress"].ToObject(typeof(int));
            var rawAvatarImg = userdata["avatarImg"].ToString();
            if (rawAvatarImg.Length > 0)
            {
                Controller.user.avatarImg = rawAvatarImg;
            }
            Controller.UpdateUserJson();
        }

        static private string recv()
        {
            string response = null;
            try
            {
                do
                {
                    int bytesToRead = stream.Read(buffer, 0, buffer.Length);
                    response += Encoding.UTF8.GetString(buffer, 0, bytesToRead);
                } while (stream.DataAvailable);
                return response;
            }
            catch (Exception) { return null; }
        }

        static private void send(in string msg)
        {
            try
            {
                stream.Write(Encoding.UTF8.GetBytes(msg), 0, msg.Length);
                System.Threading.Thread.Sleep(500);      // gibt dem Server Zeit, die Befehle zu verarbeiten
            }
            catch (Exception) { Controller.UserIsOnline = false; MainWindow.updateStatus("nicht verbunden"); }
        }
    }
}
