using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_game.Model
{
    public class ChessBoard
    {
        public ChessPiece[,] Board { get; set; } // 8x8 array of pieces
        public ChessBoard() // the coonstructor to create a 8x8 grid 
        {
            Board = new ChessPiece[8, 8];

        }
        public bool IsMoveValid(ChessPiece piece, Position newPosition) // a simple method which returns a bool T/F if it's a valid move.
        {
            return piece.IsMoveValid(newPosition, this); 
        }
    }
}
