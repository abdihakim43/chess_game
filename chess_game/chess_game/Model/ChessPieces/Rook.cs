using System;
using System.Collections.Generic;

namespace chess_game.Model.ChessPieces
{
    public class Rook : ChessPiece
    {
        public Rook(string color, Position position) : base(color, position) { }

        public override bool IsMoveValid(Position newPosition, ChessBoard board)
        {
            int currentRow = Position.Row;
            int currentCol = Position.Col;
            int targetRow = newPosition.Row;
            int targetCol = newPosition.Col;

            if (currentRow != targetRow && currentCol != targetCol)
                return false;

            int rowDir = targetRow == currentRow ? 0 : (targetRow > currentRow ? 1 : -1);
            int colDir = targetCol == currentCol ? 0 : (targetCol > currentCol ? 1 : -1);

            int r = currentRow + rowDir;
            int c = currentCol + colDir;

            while (r != targetRow || c != targetCol)
            {
                if (board.Board[r, c] != null) return false;

                r += rowDir;
                c += colDir;
            }

            var target = board.Board[targetRow, targetCol];
            return target == null || target.Color != this.Color;
        }

        public override List<(int, int)> GetValidMoves(ChessPiece[,] board, int row, int col)
        {
            var moves = new List<(int, int)>();
            var directions = new (int, int)[]
            {
                (-1, 0), (1, 0), (0, -1), (0, 1) // Up, Down, Left, Right
            };

            foreach (var (dr, dc) in directions)
            {
                int r = row + dr;
                int c = col + dc;

                while (IsInside(r, c))
                {
                    if (board[r, c] == null)
                    {
                        moves.Add((r, c));
                    }
                    else
                    {
                        if (board[r, c].Color != this.Color)
                            moves.Add((r, c));
                        break;
                    }

                    r += dr;
                    c += dc;
                }
            }

            return moves;
        }

        private bool IsInside(int row, int col) =>
            row >= 0 && row < 8 && col >= 0 && col < 8;
    }
}
