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

            foreach (var item in Controller.Stufen[Controller.currentPage].ThemenListe)
            {
                Button b = new Button();
                b.Content = item as string;
                if (item.Length > 12)
                {
                    b.FontSize = 26;
                }
                if (item.Length > 15)
                {
                    b.FontSize = 20;
                }
                if (item.Length > 20)
                {
                    b.FontSize = 17;
                }
                if (item.Length > 25)
                {
                    b.FontSize = 16;
                }
                b.MaxHeight = 60;
                b.MinWidth = 200;
                //b.Width = double.NaN;
                b.Width = 220;
                b.Margin = new Thickness(50,20,10,20);
                b.Click += AufgabenClick;
                AufgabenButtons.Children.Add(b);
            }
        }

        private void AufgabenClick(object sender, RoutedEventArgs e)
        {
            Controller.currentExercise = (sender as Button).Content as string;
            NavigationService.Navigate(new AufgabenFenster()); // Bei Klick Änderung der Page auf die das AufgabenFenster
        }

        private void ThemenBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack(); // geht eine Seite zurück
        }
    }
}
