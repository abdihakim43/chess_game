using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_game.Model
{
    public class PlayerTurn
    {
        public string CurrentPlayer { get; set; } // Property to hold the current player's color - Alex
        public PlayerTurn()
        {
            CurrentPlayer = "White"; // Initialize with White's turn - Alex
        }
        public void SwitchTurn()
        {
            // Switch the current player between "White" and "Black" - Alex
            CurrentPlayer = CurrentPlayer == "White" ? "Black" : "White";
        }
    }
}
