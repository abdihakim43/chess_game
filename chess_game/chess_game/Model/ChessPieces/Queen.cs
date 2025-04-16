using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_game.Model.ChessPieces
{
    public class Queen : ChessPiece
    {
        public Queen(string color, Position position) : base(color, position) { }

        public override bool IsMoveValid(Position newPosition, ChessBoard board)
        {
            return true; // logic for movement later
        }
    }
}
