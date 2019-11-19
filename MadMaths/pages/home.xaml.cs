using Microsoft.Win32;
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
        public List<UserRank> RankList = new List<UserRank>();

        public home()
        {
            InitializeComponent();

            if (Controller._user.UserName != null)
            {
                Username.Text = Controller._user.UserName; 
                Username.Cursor = null;
                Controller.UserIsLoggedIn = true;
            }
            else
            {
                Username.Text = "Einloggen";
            }
            if (Controller._user.avatarImg != null)
            {
                Avatar.Source = Controller.LoadImage(Convert.FromBase64String(Controller._user.avatarImg));         // lädt das Avatar Bild
            }
            if (Controller._user.level != null && Controller._user.currentProgress != null)
                /* wenn Level und Fortschritt vorhanden sind,  werden diese angezeigt */
            {
                Level.Text = Controller._user.level.ToString();
                progressInNumbers.Text = string.Format("{0}/{1}", Controller._user.currentProgress, Controller._user.level * 100);
            }
            RankList.Add(new UserRank() { UserName = "Daniel", progress = 1337 });
            RankList.Add(new UserRank() { UserName = "Rodion", progress = 69 });
            RankList.Add(new UserRank() { UserName = "Tim", progress = 420 });
            RankingList.ItemsSource = RankList;
        }

        private void StufenClick(object sender, RoutedEventArgs e)
        {
            Controller.currentPage = (sender as Button).Content.ToString();     // speichert den Namen des geclickten Buttons
            NavigationService.Navigate(new ThemenAuswahl()); // Bei Klick Änderung der Page auf die Themenauswahl
        }
        private void AvatarClick(object sender, RoutedEventArgs e)
        {
            if (Controller.UserIsLoggedIn)
            {
                CustomMB mb = new CustomMB("Die Datei darf nicht über 2MB groß sein !");
                mb.Owner = System.Windows.Application.Current.MainWindow;

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
                        mb.ShowDialog();
                        AvatarClick(sender, e);
                    }
                    else
                    {
                        using (BinaryReader br = new BinaryReader(File.Open(op.FileName, FileMode.Open))) // liest das Bild ein in bytes
                        { Controller.UpdateAvatarImg(br, fi.Length); }       // updatet die User Daten
                        Avatar.Source = Controller.LoadImage(Convert.FromBase64String(Controller._user.avatarImg));     // liest die updatete avatarImg Property wieder aus und updatet das icon
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
