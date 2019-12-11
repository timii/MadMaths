using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using System.IO;
using System.Windows.Media.Imaging;

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

            if (Controller.user.UserName != null)
            {
                Username.Text = Controller.user.UserName;
                Username.Cursor = null;
                Controller.UserIsLoggedIn = true;
            }
            else
            {
                Username.Text = "Einloggen";
            }
            if (Controller.user.avatarImg != null)
            {
                Avatar.Source = Controller.LoadImage(Convert.FromBase64String(Controller.user.avatarImg));         // lädt das Avatar Bild
            }
            Level.Text = Controller.user.level.ToString();
            progressInNumbers.Text = string.Format("{0}/{1}", Controller.user.currentProgress, Controller.user.level * 100);
            RankingList.ItemsSource = Controller.ranklist;
            progress.Value = Controller.user.currentProgress;
            progress.Maximum = Controller.user.level * 100;

            // Zum Laden der letzten Übungen
            if (Controller.user.lastSessions != null)
            {
                ShowLastSessions();
            }      
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
                CustomMB mb = new CustomMB("Die Datei darf nicht über 1MB groß sein !");
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
                    if (fi.Length > 1000000)
                    {
                        mb.ShowDialog();
                        AvatarClick(sender, e);
                    }
                    else
                    {
                        using (BinaryReader br = new BinaryReader(File.Open(op.FileName, FileMode.Open))) // liest das Bild ein in bytes
                        { Controller.UpdateAvatarImg(br, fi.Length); }       // updatet die User Daten
                        Avatar.Source = Controller.LoadImage(Convert.FromBase64String(Controller.user.avatarImg));     // liest die updatete avatarImg Property wieder aus und updatet das icon
                    }
                }
            }
            GC.Collect();
        }

        private void Username_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!Controller.UserIsLoggedIn)
            {
                NavigationService.Navigate(new login());
            }
        }

        private void ShowLastSessions() 
        {
            var temp = Controller.user.lastSessions.Split(',');
            List<string[]> lastSessions = new List<string[]>();
            Array.Reverse(temp);
            Array.ForEach(temp, x => lastSessions.Add(x.Split(':')));
            foreach (var item in lastSessions
                .Take(3))
            {
                //lastSessionsPanel.Children.Add(new Separator());
                Button b = new Button();
                b.Tag = item[0];
                b.Content = item[1];
                Style style = this.FindResource("LetzteAufgabenPanelButton") as Style;
                b.Style = style;
                b.Click += AufgabenClick;
                lastSessionsPanel.Children.Add(b);
            }
        }
        private void AufgabenClick(object sender, RoutedEventArgs e)
        {
            Controller.currentPage = (sender as Button).Tag as string;
            Controller.currentExercise = (sender as Button).Content as string;
            NavigationService.Navigate(new AufgabenFenster()); // Bei Klick Änderung der Page auf die das AufgabenFenster
        }

        private void SettingClick(object sender, RoutedEventArgs e)
        {
            if ((bool)new SettingsWindow().ShowDialog())
            {
                Username.Text = "Einloggen";
                Avatar.Source = new BitmapImage(new Uri("MadMaths;component/assets/icons/profile-picture-icon.jpg", UriKind.Relative));
                Username.Cursor = Cursors.Hand;
            }
        }
        private void ChallengeClick(object sender, RoutedEventArgs e)
        {
            Controller.currentPage = (sender as Button).Content.ToString();     // speichert den Namen des geclickten Buttons
            NavigationService.Navigate(new challengeAuswahl()); // Bei Klick Änderung der Page auf die challengeAuswahl
        }
    }
}
