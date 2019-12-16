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
        static public int versucheAnzahl = 10;

        static public Dictionary<string, int> Versuche = new Dictionary<string, int>()
        {
            {"Grundschule",versucheAnzahl},
            {"Mittelstufe", versucheAnzahl},
            {"Oberstufe", versucheAnzahl}
        };
        public challengeAuswahl()
        {
            InitializeComponent();
            GrundschuleFortschritt.Text = string.Format("{0}/{1}", Controller.challenge["Grundschule"], versucheAnzahl);
            MittelstufeFortschritt.Text = string.Format("{0}/{1}", Controller.challenge["Mittelstufe"], versucheAnzahl);
            OberstufeFortschritt.Text = string.Format("{0}/{1}", Controller.challenge["Oberstufe"], versucheAnzahl);
            if (Versuche["Grundschule"] <= 0) { Grundschule.IsEnabled = false; }
            if (Versuche["Mittelstufe"] <= 0) { Mittelstufe.IsEnabled = false; }
            if (Versuche["Oberstufe"] <= 0) { Oberstufe.IsEnabled = false; }
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
            AufgabenFenster.ChallengeMode = true;
            NavigationService.Navigate(new AufgabenFenster()); // Bei Klick Änderung der Page auf die das AufgabenFenster
        }

    }
}
