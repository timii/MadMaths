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
    /// Interaktionslogik für challengeAuswahl.xaml
    /// </summary>
    public partial class challengeAuswahl : Page
    {
        public challengeAuswahl()
        {
            InitializeComponent();
            GrundschuleFortschritt.Text = string.Format("{0}/{1}", challengeAufgabenFenster.getGSAnzRichtig(), 10);
            MittelstufeFortschritt.Text = string.Format("{0}/{1}", challengeAufgabenFenster.getMSAnzRichtig(), 10);
            OberstufeFortschritt.Text = string.Format("{0}/{1}", challengeAufgabenFenster.getOSAnzRichtig(), 10);
        }
        private void ThemenBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new home()); // Bei Klick zurück auf die Startseite;
        }
        private void AufgabenClick(object sender, RoutedEventArgs e)
        {   
            Controller.currentPage = (sender as Button).Content as string;
            List<string> myList = Controller.Stufen[Controller.currentPage].ThemenListe;
            Random rand = new Random();
            int index = rand.Next(myList.Count);
            Controller.currentExercise = myList[index];
            NavigationService.Navigate(new challengeAufgabenFenster()); // Bei Klick Änderung der Page auf die das AufgabenFenster
        }

    }
}
