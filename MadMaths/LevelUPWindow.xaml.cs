using System.Windows;

namespace MadMaths
{
    /// <summary>
    /// Interaktionslogik für LevelUPWindow.xaml
    /// </summary>
    public partial class LevelUpWindow : Window
    {
        public LevelUpWindow(string lvl)
        {
            InitializeComponent();
            LevelPopUp.Text = lvl;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
