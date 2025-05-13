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
using System.Windows.Shapes;

using System.Windows;

namespace chess_game.View
{
    public partial class WinnerWindow : Window
    {
        public WinnerWindow(string winner)
        {
            InitializeComponent();
            WinnerMessage.Text = $"{winner} is in checkmate! Game over.";

            // Subscribe to the Closed event
            this.Closed += WinnerWindow_Closed;
        }

        private void WinnerWindow_Closed(object? sender, System.EventArgs e)
        {
            // Restart the game by calling ResetGame in MainWindow
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.ResetGame();
            }
        }
    }
}

