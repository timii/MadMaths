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

namespace MadMaths.pages
{
    /// <summary>
    /// Interaktionslogik für home.xaml
    /// </summary>
    public partial class home : Page
    {
        public home()
        {
            InitializeComponent();
        }

        private void StufenClick(object sender, RoutedEventArgs e)
        {
            Controller.currentPage = (sender as Button).Content.ToString();     // speichert den Namen des geclickten Buttons
            NavigationService.Navigate(new ThemenAuswahl()); // Bei Klick Änderung der Page auf die Themenauswahl
        }
        private void AvatarClick(object sender, RoutedEventArgs e) {
            OpenFileDialog op = new OpenFileDialog
            {
                Title = "Wähle ein Bild als Avatar aus",
                Filter = "Alle supportete Grafiken| *.jpg;*.jpeg;*.png|" +
                 "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg" +
                 "Portable Network Graphic (*.png)|*.png"
            };

            if (op.ShowDialog() == true)
            {
                FileInfo fi = new FileInfo(op.FileName);
                if (fi.Length > 2000000) {

                }

                //Avatar.Source = new BitmapImage(new Uri(op.FileName));
            }

        }
    }
}
