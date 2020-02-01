using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
            StufenName.Text = Controller.currentGrade;   // setzt die aktuelle Stufe als Überschrift

            // Buttons werden dynamisch erzeugt; dabei wird die Schriftgröße an die Länge des Themennamens angepasst
            foreach (var item in Controller.Stufen[Controller.currentGrade].ThemenListe)
            {
                Button b = new Button();
                b.Content = item as string;
                if (item.Length > 12)
                {
                    b.FontSize = 28;
                }
                if (item.Length > 15)
                {
                    b.FontSize = 22;
                }
                if (item.Length > 20)
                {
                    b.FontSize = 19;
                }
                if (item.Length > 25)
                {
                    b.FontSize = 17;
                }
                b.Height = 80;
                b.Width = 245;
                b.Margin = new Thickness(65, 20, 50, 20);
                b.Click += AufgabenClick;
                AufgabenButtons.Children.Add(b);
            }
        }

        private void AufgabenClick(object sender, RoutedEventArgs e)
        {
            Controller.currentTheme = (sender as Button).Content as string;
            NavigationService.Navigate(new AufgabenFenster()); // Bei Klick Änderung der Page auf die das AufgabenFenster
        }

        private void ThemenBackClick(object sender, RoutedEventArgs e)
        {
            //NavigationService.GoBack(); // geht eine Seite zurück
            NavigationService.Navigate(new home());
        }
    }
}
