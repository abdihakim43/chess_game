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
        }
        private void OnCheckmateOccurred(string winner)
        {
            var winnerWindow = new WinnerWindow(winner);
            winnerWindow.ShowDialog(); // Open the window as a modal dialog
        }
    }
}

