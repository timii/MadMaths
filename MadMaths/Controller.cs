using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;
using MadMaths.calculations;

namespace MadMaths
{
    static public class Controller
    {
        public static string currentPage { get; set; } = "None";  // enthält den Namen der aktuell aufgerufenen Page

        public static string currentExercise { get; set; }

        public static bool UserIsLoggedIn = false;

        private static string UserSaveDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ".madmaths/");

        public static string UserSaveFile = Path.Combine(UserSaveDir, "user.json");

        public static User _user;           // das user Objekt, welches alle Daten des  Benutzers zur Laufzeit enthält

        public static Dictionary<string, IStufe> Stufen = new Dictionary<string, IStufe>()
        {
            {"Grundschule",new Grundschule() },
            {"Mittelstufe", new Mittelstufe() },
            {"Oberstufe", new Oberstufe() }
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

            _user = new User();

            if (ReadUserJS(out string userjson))
            {
                _user = JsonConvert.DeserializeObject<User>(userjson); // die daten werden im User Objekt gespeichert
            }
        }

        public static BitmapImage LoadImage(in byte[] imageData)
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

        public static bool CheckSaveFile()
        {
            return File.Exists(UserSaveFile);
        }

        public static void CreateSaveDir()
        {
            DirectoryInfo di = Directory.CreateDirectory(UserSaveDir);
            di.Attributes = FileAttributes.Directory | FileAttributes.Hidden; // erstellt einen versteckten Ordner

            CreateUserJS();
        }

        public static void CreateUserJS()
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
                serializer.Serialize(file, _user);                  // speichert das User objekt als user.json
            }
            fi.Attributes = FileAttributes.ReadOnly | FileAttributes.Hidden;
        }

        public static void UpdateAvatarImg(in BinaryReader img, in long fileLength)
        {
            _user.avatarImg = System.Convert.ToBase64String(img.ReadBytes((int)fileLength));
            UpdateUserJson();
        }

        public static void UpdateLevel() 
        {
            _user.currentProgress += 50;
            var maxEXP = _user.level * 100;
            if (_user.currentProgress == maxEXP)
            {
                _user.level++;
                _user.currentProgress = 0;
                LevelUpWindow lvlup = new LevelUpWindow(_user.level.ToString());
                lvlup.Owner = System.Windows.Application.Current.MainWindow;
                lvlup.ShowDialog();
            }
        }
    }
}
