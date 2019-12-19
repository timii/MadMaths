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
            getInfoUpdate();
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
            getInfoUpdate();
            reset();
        }

        private void getInfoUpdate()
        {
            switch (Controller.currentExercise)
            {
                case "Variablen5": case "Varaiblen6": InfoText.Text = "Lösung im Stil: ax + by"; break;
                case "Gleichungssystem1": case "Gleichungssystem2": case "Gleichungssystem3": InfoText.Text = "Lösung im Stil: x = a,y = b"; break;
                case "BinomischeFormeln1": case "BinomischeFormeln2": case "BinomischeFormeln3": case "BinomischeFormeln4": InfoText.Text = "Lösung im Stil: (a^2 + b^2)"; break;
                case "QuadratischeGleichungen1": InfoText.Text = "Lösung im Stil: b , a"; break;
                case "Ableiten1": case "HöherAbleiten1": InfoText.Text = "Lösung im Stil: ax^b"; break;
                case "Ableiten2": case "HöherAbleiten2": InfoText.Text = "Lösung im Stil: ax^b + cx^d bzw. ax^b"; break;
                case "Ableiten3": InfoText.Text = "Lösung im Stil: ax^b + cx^d bzw. ax^b oder ax^b + cx^d + ex^f"; break;
                case "Ableiten4": InfoText.Text = "Lösung im Stil: ax^b bzw. ax^b + cx^d"; break;
                case "Ableiten5": InfoText.Text = "Lösung im Stil: ax^b bzw ax^b + cx^d + ..."; break;
                case "Ableiten6": InfoText.Text = "Lösung im Stil: ax^b + cx^d)/(ex^f + g)^2"; break;
                case "Ableiten7": InfoText.Text = "Lösung im Stil: ae^(bx + c)"; break;
                case "Ableiten8": InfoText.Text = "Lösung im Stil: a * (bx - c)^d)"; break;
                case "Ableiten9": InfoText.Text = "Lösung im Stil: a * sin(bx) + c * cos(dx) * ex)"; break;
                case "Wendepunkte": InfoText.Text = "Lösung im Stil: (x1;y1) (x2;y2)"; break;
                case "Intergralregel1": case "Intergralregel2": InfoText.Text = "Lösung im Stil: sin(x) + a"; break;
                case "Intergralregel3": InfoText.Text = "Lösung im Stil: x * ln(x) + a + b"; break;
                case "Symmetrie": InfoText.Text = "Tipps:  Das gefragte Wort als Lösung angeben"; break;
                default: break;
            }
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
