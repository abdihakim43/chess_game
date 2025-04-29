using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_game.Model.ChessPieces
{
    public class Bishop : ChessPiece
    {
        public Bishop(string color, Position position) : base(color, position) { }

        public override bool IsMoveValid(Position newPosition, ChessBoard board)
        {
            int rowDiff = Math.Abs(newPosition.Row - Position.Row);
            int colDiff = Math.Abs(newPosition.Col - Position.Col);

            return rowDiff == colDiff;
        }

    }
}
