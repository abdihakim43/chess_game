using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_game.Model
{
    public abstract class ChessPiece
    {
        public string Color { get; set; } // white or black piece
        public Position Position { get; set; } // current position on the board

        public ChessPiece(string color, Position position) // constructor
        {
            Color = color;
            Position = position;
        }

        // Abstract method to be overridden in subclasses for each piece's movement rules
        public abstract bool IsMoveValid(Position newPosition, ChessBoard board);
    }
}
