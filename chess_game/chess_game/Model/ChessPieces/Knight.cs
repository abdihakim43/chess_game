using System;
using System.Collections.Generic;
using chess_game.Model;

namespace chess_game.Model.ChessPieces
{
    public class Knight : ChessPiece
    {
        public Knight(string color, Position position) : base(color, position) { }

        public override bool IsMoveValid(Position newPosition, ChessBoard board)
        {
            int dx = Math.Abs(newPosition.Col - Position.Col);
            int dy = Math.Abs(newPosition.Row - Position.Row);

            bool isLShape = (dx == 2 && dy == 1) || (dx == 1 && dy == 2);
            if (!isLShape)
                return false;

            var targetPiece = board.Board[newPosition.Row, newPosition.Col];
            return targetPiece == null || targetPiece.Color != this.Color;
        }

        public override List<(int, int)> GetValidMoves(ChessPiece[,] board, int row, int col)
        {
            var moves = new List<(int, int)>();
            var offsets = new (int, int)[]
            {
                (-2, -1), (-2, +1),
                (-1, -2), (-1, +2),
                (+1, -2), (+1, +2),
                (+2, -1), (+2, +1)
            };

            foreach (var (dr, dc) in offsets)
            {
                int newRow = row + dr;
                int newCol = col + dc;

                if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
                {
                    var target = board[newRow, newCol];
                    if (target == null || target.Color != this.Color)
                    {
                        moves.Add((newRow, newCol));
                    }
                }
            }

            return moves;
        }
    }
}
