using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_game.Model
{
    public class Pawn : ChessPiece
    {

        public Pawn(string color, Position position) : base(color, position) { }
        public override bool IsMoveValid(Position newPosition, ChessBoard board)
        {
            {
                int direction = Color == "White" ? -1 : 1; // White moves up (row--), Black moves down (row++)

                // 1 step forward
                if (newPosition.Col == Position.Col &&
                    newPosition.Row == Position.Row + direction &&
                    board.Board[newPosition.Row, newPosition.Col] == null)
                {
                    return true;
                }

                // 2 steps from starting position
                int startRow = Color == "White" ? 6 : 1;
                if (Position.Row == startRow &&
                    newPosition.Col == Position.Col &&
                    newPosition.Row == Position.Row + 2 * direction &&
                    board.Board[Position.Row + direction, Position.Col] == null &&
                    board.Board[newPosition.Row, newPosition.Col] == null)
                {
                    return true;
                }

                // Capturing diagonally
                if (Math.Abs(newPosition.Col - Position.Col) == 1 &&
                    newPosition.Row == Position.Row + direction &&
                    board.Board[newPosition.Row, newPosition.Col] != null &&
                    board.Board[newPosition.Row, newPosition.Col].Color != this.Color)
                {
                    return true; // Valid capture move
                }

                return false;
            }
        }
    }
}
