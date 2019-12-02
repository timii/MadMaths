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
using System.Windows.Navigation;
namespace MadMaths.pages
{
    /// <summary>
    /// Interaktionslogik für AufgabenFenster.xaml
    /// </summary>
    public partial class AufgabenFenster : Page
    {
        int anzRichtig = 0;
        bool wasFocused = false;

        public AufgabenFenster()
        {
            InitializeComponent();
            AufgabenStellung.Text = Controller.Stufen[Controller.currentPage].getAufgabenText(Controller.currentExercise);
            NextExerciseButton.IsEnabled = false;
            Controller.FillLastSessions();
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
                anzRichtig++;
                Controller.UpdateLevel();
            }
            else
            {
                Lösung.Text = "You fucking donkey"+ Environment.NewLine + _lösung;
                Lösung.Foreground = new SolidColorBrush(Colors.Red);
            }
            abgabebtn.IsEnabled = false;
            Antwort.IsReadOnly = true;
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
        }
    }
}
