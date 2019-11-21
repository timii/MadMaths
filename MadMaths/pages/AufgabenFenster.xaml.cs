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
        }

        private void ThemenBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ThemenAuswahl()); // Bei Klick zurück auf die Startseite;

        }


        private void Abgabe_Click(object sender, RoutedEventArgs e)
        {
            if (Controller.Stufen[Controller.currentPage].checksSolution(Antwort.Text))
            {
                Lösung.Text = "Richtig!";
                Lösung.Foreground = new SolidColorBrush(Colors.LawnGreen);
                NextExerciseButton.Opacity  = 100;
                anzRichtig++;
            }
            else
            {
                Lösung.Text = "You Dumbass";
                Lösung.Foreground = new SolidColorBrush(Colors.Red);
                NextExerciseButton.Opacity = 100;
            }
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
            NavigationService.Navigate(new AufgabenFenster()); // Bei Klick Änderung der Page auf die das AufgabenFenster
        }

        private void Antwort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { Abgabe_Click(null,null); }
        }

        private void ChangeButton() 
        {
            if(anzRichtig == 4)
            {
                Style style = this.FindResource("NextExerciseButton") as Style;
                NextExerciseButton.Style = style;
            }
        }
    }
}
