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
            GrundschuleFortschritt.Text = string.Format("{0}/{1}", Controller.user.grundschule, versucheAnzahl);
            MittelstufeFortschritt.Text = string.Format("{0}/{1}", Controller.user.mittelstufe, versucheAnzahl);
            OberstufeFortschritt.Text = string.Format("{0}/{1}", Controller.user.oberstufe, versucheAnzahl);
        }
        private void ThemenBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new home()); // Bei Klick zurück auf die Startseite;
        }
        private void AufgabenClick(object sender, RoutedEventArgs e)
        {
            Controller.currentGrade = (sender as Button).Content as string;
            List<string> myList = Controller.Stufen[Controller.currentGrade].ThemenListe;
            Random rand = new Random();
            int index = rand.Next(myList.Count);
            Controller.currentTheme = myList[index];
            AufgabenFenster.ChallengeMode = true;
            NavigationService.Navigate(new AufgabenFenster()); // Bei Klick Änderung der Page auf die das AufgabenFenster
        }

    }
}
