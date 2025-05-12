using System;
using System.Collections.Generic;

namespace chess_game.Model
{
    public class Pawn : ChessPiece
    {
        public Pawn(string color, Position position) : base(color, position) { }

        public override bool IsMoveValid(Position newPosition, ChessBoard board)
        {
            int direction = Color == "White" ? -1 : 1;
            int startRow = Color == "White" ? 6 : 1;

            // Move forward 1
            if (newPosition.Col == Position.Col &&
                newPosition.Row == Position.Row + direction &&
                board.Board[newPosition.Row, newPosition.Col] == null)
            {
                return true;
            }

            // Move forward 2 from starting row
            if (Position.Row == startRow &&
                newPosition.Col == Position.Col &&
                newPosition.Row == Position.Row + 2 * direction &&
                board.Board[Position.Row + direction, Position.Col] == null &&
                board.Board[newPosition.Row, newPosition.Col] == null)
            {
                return true;
            }

            // Diagonal capture
            if (Math.Abs(newPosition.Col - Position.Col) == 1 &&
                newPosition.Row == Position.Row + direction)
            {
                var target = board.Board[newPosition.Row, newPosition.Col];
                if (target != null && target.Color != this.Color)
                    return true;
            }

            return false;
        }

        public override List<(int, int)> GetValidMoves(ChessPiece[,] board, int row, int col)
        {
            var moves = new List<(int, int)>();
            int direction = Color == "White" ? -1 : 1;
            int startRow = Color == "White" ? 6 : 1;

            // Forward 1
            if (IsInside(row + direction, col) && board[row + direction, col] == null)
            {
                moves.Add((row + direction, col));

                // Forward 2
                if (row == startRow && board[row + 2 * direction, col] == null)
                {
                    moves.Add((row + 2 * direction, col));
                }
            }

            // Capture diagonally
            foreach (int dc in new int[] { -1, 1 })
            {
                int newRow = row + direction;
                int newCol = col + dc;

                if (IsInside(newRow, newCol))
                {
                    var target = board[newRow, newCol];
                    if (target != null && target.Color != this.Color)
                    {
                        moves.Add((newRow, newCol));
                    }
                }
            }

            return moves;
        }

        private bool IsInside(int row, int col)
        {
            return row >= 0 && row < 8 && col >= 0 && col < 8;
        }
    }
}
