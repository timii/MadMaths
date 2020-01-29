using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        // Einlesen der Sounddateien
        private readonly Uri RightAnswer = new Uri("MadMaths;component/assets/sound/correct.wav", UriKind.Relative);
        private readonly Uri WrongAnswer = new Uri("MadMaths;component/assets/sound/wrong.wav", UriKind.Relative);
        private readonly Uri helperSound = new Uri("MadMaths;component/assets/sound/empty.wav", UriKind.Relative);
        private readonly SoundPlayer Right, Wrong;
        private BackgroundWorker timer;

        private static int ChallengeVersuche = 10;

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
                TimerProgress.Visibility = Visibility.Visible;
                NextExerciseButton.Click -= NextExerciseButton_Click;
                NextExerciseButton.Click += NextChallengeButton_Click;
                timer = new BackgroundWorker();
                timer.WorkerReportsProgress = true;
                timer.DoWork += timer_DoWork;
                timer.ProgressChanged += timer_ProgressChanged;
                timer.RunWorkerCompleted += timer_ProgressCompleted;
                timer.WorkerSupportsCancellation = true;
                StartTimer();
            }
            getInfoUpdate();
        }

        ~AufgabenFenster()
        {
            Right.Dispose();Wrong.Dispose();
            if (timer != null) timer.Dispose();
        }

        private void ThemenBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack(); // Bei Klick zurück auf die Startseite;
        }

        private void Abgabe_Click(object sender, RoutedEventArgs e)
        {
            abgabebtn.IsEnabled = false;
            Antwort.IsReadOnly = true;
            Antwort.Focusable = false;
            if (Controller.Stufen[Controller.currentGrade].checksSolution(Antwort.Text, out string _lösung))
            {
                Lösung.Text = "Richtig!";
                Lösung.Foreground = new SolidColorBrush(Colors.LawnGreen);
                if (SettingsWindow.IsSoundOn) Right.Play();
                if (ChallengeMode)
                {
                    Controller.UpdateChallengeData();
                    switch (Controller.currentGrade)
                    {
                        case "Grundschule": Controller.UpdateLevel(1.3f); break;
                        case "Mittelstufe": Controller.UpdateLevel(1.5f); break;
                        case "Oberstufe": Controller.UpdateLevel(2f); break;
                    }
                }
                else Controller.UpdateLevel();
            }
            else
            {
                Lösung.Text = "Falsch!" + Environment.NewLine + _lösung;
                Lösung.Foreground = new SolidColorBrush(Colors.Red);
                if (SettingsWindow.IsSoundOn) Wrong.Play();
            }
            if (ChallengeMode)
            {
                timer.CancelAsync();
                --ChallengeVersuche;
                if (ChallengeVersuche <= 0)
                {
                    ChallengeMode = false;
                    ChallengeVersuche = 10;
                    NavigationService.Navigate(new challengeAuswahl());
                }
            }
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
            AufgabenStellung.Text = Controller.Stufen[Controller.currentGrade].getAufgabenText(Controller.currentTheme); // Speichereffizienter
            getInfoUpdate();
            reset();
        }

        private void getInfoUpdate()
        {
            switch (Controller.currentExercise)
            {
                case "Variablen5": case "Variablen6": InfoText.Text = "Lösung im Stil: ax + by"; break;
                case "TeilenmitRest1": InfoText.Text = "Integerdivison, keine nachkommastellen"; break;
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
                case "Symmetrie": InfoText.Text = "Tipps:  Das gefragte Wort als Lösung angeben"; InfoText0.Text = ""; break;
                case "Umwandeln1": case "Umwandeln2":case "Umwandeln3":case "Umwandeln4": case "Umwandeln5": InfoText0.Text = "Tipps: \nAuf 3 Nachkommastellen runden"; break;

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

        // setzt den Timer für die Herausforderungen der verschiedenen Stufen
        #region ["Challenge Timer"]
        private void StartTimer()
        {
            TimerProgress.Value = 0;
            switch (Controller.currentGrade)
            {
                case "Grundschule": TimerProgress.Maximum = 3000; break;   // 30 Sekunden
                case "Mittelstufe": TimerProgress.Maximum = 4000; break;  // 40 Sekunden
                case "Oberstufe": TimerProgress.Maximum = 4000; break;
            }
            timer.RunWorkerAsync(TimerProgress.Maximum);
        }

        private void timer_DoWork(object sender, DoWorkEventArgs e)
        {
            int max = Convert.ToInt32(e.Argument);
            for (int i = 0; i <= max; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                if (timer.CancellationPending) return;
                System.Threading.Thread.Sleep(10);
            }
        }
        
        private void timer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TimerProgress.Value = e.ProgressPercentage;
        }

        private void timer_ProgressCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TimerProgress.Value = TimerProgress.Maximum;
            if (abgabebtn.IsEnabled) Abgabe_Click(null, null);
        }
        #endregion
    }
}
