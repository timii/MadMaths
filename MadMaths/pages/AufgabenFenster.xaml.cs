using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace MadMaths.pages
{
    /// <summary>
    /// Interaktionslogik für AufgabenFenster.xaml
    /// </summary>
    public partial class AufgabenFenster : Page
    {
        bool wasFocused = false;
        public static bool ChallengeMode = false;

        public AufgabenFenster()
        {
            InitializeComponent();
            AufgabenStellung.Text = Controller.Stufen[Controller.currentPage].getAufgabenText(Controller.currentExercise);
            NextExerciseButton.IsEnabled = false;
            if (!ChallengeMode) Controller.FillLastSessions();
            ThemenName.Text = Controller.currentExercise;
            if (ChallengeMode)
            {
                BackButton.Visibility = Visibility.Hidden;
                NextExerciseButton.Click -= NextExerciseButton_Click;
                NextExerciseButton.Click += NextChallengeButton_Click;
            }

             
            switch (Controller.currentExercise)
            {
                case "Addieren": InfoText.Text += "\n"; break; 
                default:InfoText.Text += "\n"; break;
            }
        }

        private void ThemenBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack(); // Bei Klick zurück auf die Startseite;
        }

        private void Abgabe_Click(object sender, RoutedEventArgs e)
        {


            if (Controller.Stufen[Controller.currentPage].checksSolution(Antwort.Text, out string _lösung))
            {
                Lösung.Text = "Richtig!";
                Lösung.Foreground = new SolidColorBrush(Colors.LawnGreen);
                Controller.UpdateLevel();
                if (ChallengeMode) Controller.UpdateChallengeData();
            }
            else
            {
                Lösung.Text = "Falsch!" + Environment.NewLine + _lösung;
                Lösung.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (ChallengeMode)
            {
                --challengeAuswahl.Versuche[Controller.currentPage];
                if (challengeAuswahl.Versuche[Controller.currentPage] <= 0)
                {
                    ChallengeMode = false;
                    NavigationService.Navigate(new challengeAuswahl());
                }
            }
            abgabebtn.IsEnabled = false;
            Antwort.IsReadOnly = true;
            Antwort.Focusable = false;
            NextExerciseButton.Opacity = 100;
            NextExerciseButton.IsEnabled = true;
        }

        private void Antwort_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (!wasFocused)
            {
                Antwort.Text = "";
                wasFocused = true;
            }
        }

        private void NextExerciseButton_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new AufgabenFenster()); // Bei Klick Änderung der Page auf die das AufgabenFenster
            AufgabenStellung.Text = Controller.Stufen[Controller.currentPage].getAufgabenText(Controller.currentExercise); // Speichereffizienter
            reset();
        }

        private void Antwort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { Abgabe_Click(null, null); }
        }

        private void reset()
        {
            Antwort.Text = "";
            Lösung.Text = "";
            abgabebtn.IsEnabled = true;
            NextExerciseButton.IsEnabled = false;
            NextExerciseButton.Opacity = 0;
            Antwort.IsReadOnly = false;
            Antwort.Focusable = true;
        }

        private void NextChallengeButton_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new AufgabenFenster()); // Bei Klick Änderung der Page auf die das AufgabenFenster
            //AufgabenStellung.Text = Controller.Stufen[Controller.currentPage].getAufgabenText(Controller.currentExercise); // Speichereffizienter
            //reset();
            List<string> myList = Controller.Stufen[Controller.currentPage].ThemenListe;
            Random rand = new Random();
            int index = rand.Next(myList.Count);
            Controller.currentExercise = myList[index];
            NavigationService.Navigate(new AufgabenFenster()); // Bei Klick Änderung der Page auf die das AufgabenFenster
        }

        private void InfoClick(object sender, RoutedEventArgs e)
        {
            if (InfoPopup.IsOpen == false)
            {
                InfoPopup.IsOpen = true;
            }
            else
            {
                InfoPopup.IsOpen = false;
            }
        }
    }
}
