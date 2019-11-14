﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;

namespace MadMaths
{
    static public class Controller
    {
        public static string currentPage { get; set; } = "None";  // enthält den Namen der aktuell aufgerufenen Page

        public static bool UserIsLoggedIn = false;

        private static string UserSaveDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ".madmaths/");

        public static string UserSaveFile = Path.Combine(UserSaveDir, "user.json");

        public static User _user;           // das user Objekt, welches alle Daten des  Benutzers zur Laufzeit enthält

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

        public static BitmapImage LoadImage(byte[] imageData)
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
    }
}
