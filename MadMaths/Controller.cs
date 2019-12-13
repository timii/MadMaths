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
    static public class Controller
    {
        public static string currentPage { get; set; } = "None";  // enthält den Namen der aktuell aufgerufenen Page
        public static string currentExercise { get; set; }

        public static bool UserIsLoggedIn = false;

        public static bool UserIsOnline = false;

        private static readonly string UserSaveDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ".madmaths/");

        public static readonly string UserSaveFile = Path.Combine(UserSaveDir, "user.json");

        public static User user;           // das user Objekt, welches alle Daten des Benutzers zur Laufzeit enthält
        public static List<UserRank> ranklist = new List<UserRank>();
        public static Challenge _challenge = new Challenge();

        public static Dictionary<string, IStufe> Stufen = new Dictionary<string, IStufe>()
        {
            {"Grundschule",new Grundschule() },
            {"Mittelstufe", new Mittelstufe() },
            {"Oberstufe", new Oberstufe() }
        };

        public static Dictionary<string, int> challenge = new Dictionary<string, int>()
        {
            {"Grundschule", _challenge.grundschule },
            {"Mittelstufe", _challenge.mittelstufe },
            {"Oberstufe", _challenge.oberstufe }
        };

        static Controller()
        {
            // Initialisierung
            if (!CheckSaveDir())
            {
                CreateSaveDir();
            }
            if (!CheckSaveFile())
            {
                CreateUserJS();
            }
            FileInfo fi = new FileInfo(UserSaveFile);
            fi.Attributes = FileAttributes.Normal;

            user = new User();

            if (ReadUserJS(out string userjson))
            {
                user = JsonConvert.DeserializeObject<User>(userjson); // die daten werden im User Objekt gespeichert
            }
        }
        
        public static BitmapImage LoadImage(in byte[] imageData)    // Code von https://bit.ly/2YFCn3E
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

        public static bool CheckSaveDir()           // überprüft, ob der .madmaths Ordner vorhanden ist
        {
            return Directory.Exists(UserSaveDir);
        }

        public static bool CheckSaveFile()          // überprüft, ob die user.json vorhanden ist
        {
            return File.Exists(UserSaveFile);
        }

        public static void CreateSaveDir()
        {
            DirectoryInfo di = Directory.CreateDirectory(UserSaveDir);
            di.Attributes = FileAttributes.Directory | FileAttributes.Hidden; // erstellt einen versteckten Ordner

            CreateUserJS();
        }

        public static void CreateUserJS()           // erstellt die user.json
        {
            using (File.Create(UserSaveFile)) { };
        }

        public static bool ReadUserJS(out string UserJson)
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

        public static void UpdateUserJson()
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

        public static void UpdateAvatarImg(in BinaryReader img, in long fileLength)
        {
            user.avatarImg = System.Convert.ToBase64String(img.ReadBytes((int)fileLength));
            UpdateUserJson();
            Task.Run(() => Client.UpdateAvatar());
        }

        public static void UpdateLevel(in int exp)
        {
            var maxEXP = user.level * 100;
            if (user.currentProgress+exp <= maxEXP){ user.currentProgress += exp; }
            else { user.currentProgress = maxEXP; }
            
            if (user.currentProgress >= maxEXP && user.level < 99)
            {
                ++user.level;
                user.currentProgress = 0;
                LevelUpWindow lvlup = new LevelUpWindow(user.level.ToString());
                lvlup.Owner = System.Windows.Application.Current.MainWindow;
                lvlup.ShowDialog();
            }
        }

        public static void FillLastSessions()
        {
            if (user.lastSessions != null)
            {
                user.lastSessions += ',';
            }
            user.lastSessions += currentPage + ':' + currentExercise;
            UpdateUserJson();
        }

        public static void CreateRankList()
        {
            var stringjson = Client.GetRanklist();
            var rawjson = JObject.Parse(stringjson);
            foreach (var item in rawjson)
            {
                ranklist.Add(new UserRank() { UserName = item.Key, Points = Int32.Parse(item.Value["Points"].ToString()),
                                              avatarImg = LoadImage(Convert.FromBase64String(item.Value["avatarImg"].ToString())) });
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
                //client = new TcpClient("45.88.108.218", 7777);
                client = new TcpClient("uselesscode.works", 7777);
                stream = client.GetStream();
                buffer = new byte[1024];
                if (CheckConnection())
                {
                    Controller.UserIsOnline = true;
                }
                else { throw new SocketException(); }
            }
            catch (SocketException)
            {
                //new CustomMB("Verbindung zum Server fehlgeschlagen").ShowDialog();
            }
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
                for (int i = 0; i < 50; i++)
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

        static public string RegisterUser(in string username, in string usrpwd)
        {
            if (Controller.UserIsOnline)
            {
                string msg = string.Format("REGISTERUSER_{0}_{1}", username, usrpwd);
                send(msg);
                return recv();
            }
            return null;
        }

        static public bool LoginUser(in string username, in string pw)
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

        static public bool LoginUser()
        {
            return LoginUser(Controller.user.UserName, Controller.user.password);
        }

        static public void LogoutUser()
        {
            send("LOGOUTUSER");
        }

        static public bool CheckUsername(in string username)
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

        static public void UpdateAvatar()
        {
            string msg = "UPDATEAVATARIMG";
            send(msg);
            send(Controller.user.avatarImg);
            send("ENDIMGSTREAM");
        }

        static public void UpdateUserData(in string cmd)
        {
            if (Controller.UserIsLoggedIn)
            {
                string msg = string.Format("UPDATEUSERDATA_{0}_{1}_{2}", cmd, Controller.user.level, Controller.user.currentProgress);
                send(msg);
            }
        }

        static public string GetRanklist()
        {
            if (Controller.UserIsOnline)
            {
                string msg = "GETRANKLIST";
                send(msg);
                return recv();
            }
            return null;
        }

        static public async Task GetUserData()
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
            catch (Exception) { Controller.UserIsOnline = false; MainWindow.updateStatus("offline"); }
        }
    }
}
