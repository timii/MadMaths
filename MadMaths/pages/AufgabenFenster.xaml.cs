using System;
using System.Collections.Generic;
using System.Media;
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
        private readonly Uri RightAnswer = new Uri("MadMaths;component/assets/sound/correct.wav", UriKind.Relative);
        private readonly Uri WrongAnswer = new Uri("MadMaths;component/assets/sound/wrong.wav", UriKind.Relative);
        private readonly Uri helperSound = new Uri("MadMaths;component/assets/sound/empty.wav", UriKind.Relative);
        private readonly SoundPlayer Right, Wrong;

        public AufgabenFenster()
        {
            Right = new SoundPlayer(Application.GetResourceStream(RightAnswer).Stream);
            Wrong = new SoundPlayer(Application.GetResourceStream(WrongAnswer).Stream);
            var helper = new SoundPlayer(Application.GetResourceStream(helperSound).Stream);
            helper.Play(); helper.Dispose();
            InitializeComponent();
            AufgabenStellung.Text = Controller.Stufen[Controller.currentGrade].getAufgabenText(Controller.currentTheme);
            NextExerciseButton.IsEnabled = false;
            if (!ChallengeMode) Controller.FillLastSessions();
            ThemenName.Text = Controller.currentTheme;
            if (ChallengeMode)
            {
                BackButton.Visibility = Visibility.Hidden;
                NextExerciseButton.Click -= NextExerciseButton_Click;
                NextExerciseButton.Click += NextChallengeButton_Click;
            }
  
            switch (Controller.currentTheme)
            {
                case "Addieren": InfoText.Text += "\n"; break; 
                default:InfoText.Text += "\n"; break;
            }
        }

        ~AufgabenFenster()
        {
            Right.Dispose();Wrong.Dispose();
        }

        private void ThemenBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack(); // Bei Klick zurück auf die Startseite;
        }

        private void Abgabe_Click(object sender, RoutedEventArgs e)
        {

            if (Controller.Stufen[Controller.currentGrade].checksSolution(Antwort.Text, out string _lösung))
            {
                Lösung.Text = "Richtig!";
                Lösung.Foreground = new SolidColorBrush(Colors.LawnGreen);
                Right.Play();
                switch (Controller.currentGrade)
                {
                    case "Grundschule": Controller.UpdateLevel(1.3f);break;
                    case "Mittelstufe": Controller.UpdateLevel(1.5f);break;
                    case "Oberstufe": Controller.UpdateLevel(2f);break;
                    default: Controller.UpdateLevel();break;
                }
                if (ChallengeMode) Controller.UpdateChallengeData();
            }
            else
            {
                Lösung.Text = "Falsch!" + Environment.NewLine + _lösung;
                Lösung.Foreground = new SolidColorBrush(Colors.Red);
                Wrong.Play();
            }
            if (ChallengeMode)
            {
                --challengeAuswahl.Versuche[Controller.currentGrade];
                if (challengeAuswahl.Versuche[Controller.currentGrade] <= 0)
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
            AufgabenStellung.Text = Controller.Stufen[Controller.currentGrade].getAufgabenText(Controller.currentTheme); // Speichereffizienter
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
            List<string> myList = Controller.Stufen[Controller.currentGrade].ThemenListe;
            Random rand = new Random();
            int index = rand.Next(myList.Count);
            Controller.currentTheme = myList[index];
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
