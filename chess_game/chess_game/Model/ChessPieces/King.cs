using System;
using System.Collections.Generic;

namespace chess_game.Model.ChessPieces
{
    public class King : ChessPiece
    {
        public King(string color, Position position) : base(color, position) { }

        public override bool IsMoveValid(Position newPosition, ChessBoard board)
        {
            int rowDiff = Math.Abs(newPosition.Row - Position.Row);
            int colDiff = Math.Abs(newPosition.Col - Position.Col);

            if (rowDiff <= 1 && colDiff <= 1)
            {
                var target = board.Board[newPosition.Row, newPosition.Col];
                return target == null || target.Color != this.Color;
            }

            return false;
        }

        public override List<(int, int)> GetValidMoves(ChessPiece[,] board, int row, int col)
        {
            var moves = new List<(int, int)>();

            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    if (dr == 0 && dc == 0) continue;

                    int r = row + dr;
                    int c = col + dc;

                    if (IsInside(r, c))
                    {
                        var target = board[r, c];
                        if (target == null || target.Color != this.Color)
                        {
                            moves.Add((r, c));
                        }
                    }
                }
            }

            return moves;
        }

        private bool IsInside(int row, int col) =>
            row >= 0 && row < 8 && col >= 0 && col < 8;
    }
}
