using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MadMaths.pages
{
    public partial class challengeAuswahl : Page
    {
        internal static int challengeVersucheGesamt = 10;      // Anzahl der Fragen die bei einer Herausforderung kommen
        public challengeAuswahl()
        {
            InitializeComponent();
            GrundschuleFortschritt.Text = string.Format("{0}/{1}", Controller.user.grundschule, challengeVersucheGesamt);
            MittelstufeFortschritt.Text = string.Format("{0}/{1}", Controller.user.mittelstufe, challengeVersucheGesamt);
            OberstufeFortschritt.Text = string.Format("{0}/{1}", Controller.user.oberstufe, challengeVersucheGesamt);
        }
        private void ThemenBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new home()); // Bei Klick zurück auf die Startseite;
        }
        private void AufgabenClick(object sender, RoutedEventArgs e)
        {
            Controller.currentGrade = (sender as Button).Content as string;
            switch (Controller.currentGrade)
            {
                case "Grundschule": Controller.user.grundschule = 0; break;
                case "Mittelstufe": Controller.user.mittelstufe = 0; break;
                case "Oberstufe": Controller.user.oberstufe = 0; break;
            }
            List<string> myList = Controller.Stufen[Controller.currentGrade].ThemenListe;
            Random rand = new Random();
            int index = rand.Next(myList.Count);
            Controller.currentTheme = myList[index];
            AufgabenFenster.ChallengeMode = true;
            NavigationService.Navigate(new AufgabenFenster()); // Bei Klick Änderung der Page auf die das AufgabenFenster
        }

    }
}
