using System.Windows;

namespace chess_game.View
{
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void PvP_Click(object sender, RoutedEventArgs e)
        {
            MainWindow gameWindow = new MainWindow("PvP");
            gameWindow.Show();
            this.Close();
        }

        private void PvE_Click(object sender, RoutedEventArgs e)
        {
            MainWindow gameWindow = new MainWindow("PvE");
            gameWindow.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
