using System;
using System.Collections.Generic;

namespace chess_game.Model.ChessPieces
{
    public class Queen : ChessPiece
    {
        public Queen(string color, Position position) : base(color, position) { }

        public override bool IsMoveValid(Position newPosition, ChessBoard board)
        {
            int rowDiff = Math.Abs(newPosition.Row - Position.Row);
            int colDiff = Math.Abs(newPosition.Col - Position.Col);

            if (rowDiff == colDiff || Position.Row == newPosition.Row || Position.Col == newPosition.Col)
            {
                int rowDir = Math.Sign(newPosition.Row - Position.Row);
                int colDir = Math.Sign(newPosition.Col - Position.Col);

                int r = Position.Row + rowDir;
                int c = Position.Col + colDir;

                while (r != newPosition.Row || c != newPosition.Col)
                {
                    if (board.Board[r, c] != null) return false;
                    r += rowDir;
                    c += colDir;
                }

                var target = board.Board[newPosition.Row, newPosition.Col];
                return target == null || target.Color != this.Color;
            }

            return false;
        }

        public override List<(int, int)> GetValidMoves(ChessPiece[,] board, int row, int col)
        {
            var moves = new List<(int, int)>();
            int[] directions = { -1, 0, 1 };

            foreach (int dr in directions)
            {
                foreach (int dc in directions)
                {
                    if (dr == 0 && dc == 0) continue;

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
            }

            return moves;
        }

        private bool IsInside(int row, int col) =>
            row >= 0 && row < 8 && col >= 0 && col < 8;
    }
}
