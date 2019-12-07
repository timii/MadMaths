using System.Windows;

namespace MadMaths
{
    /// <summary>
    /// Interaktionslogik für CustomMB.xaml (Custom Messagebox)
    /// </summary>
    public partial class CustomMB : Window
    {
        public CustomMB(string msg)
        {
            InitializeComponent();
            msgBox.Text = msg;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
