﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Newtonsoft.Json;

namespace MadMaths.pages
{
    /// <summary>
    /// Interaktionslogik für home.xaml
    /// </summary>
    public partial class home : Page
    {

        public string temp;

        public home()
        {
            InitializeComponent();
            User user = new User();
            Controller.ReadUserJS(); // die JSON wird als string eingelesen
            if (Controller.UserJson.Length !=0)
            {
                user = JsonConvert.DeserializeObject<User>(Controller.UserJson); // die daten werden im User Objekt gespeichert
            }

            if (user.UserName != null)
            {
                Username.Text = user.UserName;
                Controller.UserIsLoggedIn = true;
            }
            else
            {
                Username.Text = "Einloggen";
            }
        }

        private void StufenClick(object sender, RoutedEventArgs e)
        {
            Controller.currentPage = (sender as Button).Content.ToString();     // speichert den Namen des geclickten Buttons
            NavigationService.Navigate(new ThemenAuswahl()); // Bei Klick Änderung der Page auf die Themenauswahl
        }
        private void AvatarClick(object sender, RoutedEventArgs e) {
            if (Controller.UserIsLoggedIn)
            {

                OpenFileDialog op = new OpenFileDialog
                {
                    Title = "Wähle ein Bild als Avatar aus",
                    Filter = "Alle Bilder| *.jpg;*.jpeg;*.png|" +
                     "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                     "Portable Network Graphic (*.png)|*.png"
                };

                if (op.ShowDialog() == true)
                {
                    FileInfo fi = new FileInfo(op.FileName);
                    if (fi.Length > 2000000)
                    {
                        MessageBox.Show("Die Datei darf nicht über 2 MB groß sein", "Datei zu groß");
                        AvatarClick(sender, e);
                    }
                    else
                    {
                        using (StreamReader sr = new StreamReader("user.json"))
                        {
                            temp = sr.ReadToEnd();
                        }
                        //User user = JsonConvert.DeserializeObject<User>(temp); // ignoriert diesen Abschnitt
                        //using (BinaryReader br = new BinaryReader(File.Open(op.FileName, FileMode.Open)))
                        //{
                        //    temp = System.Convert.ToBase64String(br.ReadBytes((int)fi.Length));
                        //}
                        //using (StreamWriter sw = new StreamWriter(File.Open("img.txt", FileMode.CreateNew)))
                        //{
                        //    sw.Write(temp);
                        //}
                        Avatar.Source = new BitmapImage(new Uri(op.FileName));
                        //Avatar.Source = Controller.LoadImage(Convert.FromBase64String(user.avatarImg));
                    }
                }
            }

        }

        private void Username_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!Controller.UserIsLoggedIn)
            {
                NavigationService.Navigate(new login());
            }
        }
    }
}
