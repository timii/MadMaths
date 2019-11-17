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

namespace MadMaths.pages
{
    /// <summary>
    /// Interaktionslogik für ThemenAuswahl.xaml
    /// </summary>
    public partial class ThemenAuswahl : Page
    {
        public ThemenAuswahl()
        {
            InitializeComponent();
            StufenName.Text = Controller.currentPage;   // setzt die aktuelle Stufe als Überschrift
            Grundschule t = new Grundschule();
            string temp = t.AufgabenListe[0];

            foreach (var item in t.AufgabenListe)
            {
                Button b = new Button();
                b.Content = item as string;
                b.MaxHeight = 60;
                b.MinWidth = 300;
                b.Width = double.NaN;
                b.Margin = new Thickness(50,20,40,20);
                b.Click += AufgabenClick;
                AufgabenButtons.Children.Add (b);
            }
        }

        private void AufgabenClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AufgabenFenster()); // Bei Klick Änderung der Page auf die das AufgabenFenster
        }

        private void ThemenBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack(); // geht eine Seite zurück
        }
    }
}
