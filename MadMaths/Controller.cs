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

        public static string UserSaveFile = Path.Combine(UserSaveDir,"user.json");

        public static string UserJson;

        static Controller()
        {
            //
        }


        public static BitmapImage LoadImage(byte[] imageData)
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

        public static bool CheckSaveDir()
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

            //FileInfo fi = new FileInfo(UserSaveFile);
            //fi.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            CreateUserJS();
        }

        public static void CreateUserJS()
        {
            DirectoryInfo di = new DirectoryInfo(UserSaveDir);
            di.Attributes = FileAttributes.Normal;
            File.Create(UserSaveFile);
            di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
        }

        public static void ReadUserJS()
        {
            using (StreamReader sr = new StreamReader(UserSaveFile))
            {
                UserJson = sr.ReadToEnd();
            }

        }
    }
}   
