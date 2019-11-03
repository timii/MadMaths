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
        }

        private void AufgabenClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AufgabenFenster()); // Bei Klick Änderung der Page auf die das AufgabenFenster
        }
    }
}
