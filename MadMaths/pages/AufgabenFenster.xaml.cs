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
    /// Interaktionslogik für AufgabenFenster.xaml
    /// </summary>
    public partial class AufgabenFenster : Page
    {
        public AufgabenFenster()
        {
            InitializeComponent();
        }

        private void ThemenBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ThemenAuswahl()); // Bei Klick zurück auf die Startseite
        }
    }
}
