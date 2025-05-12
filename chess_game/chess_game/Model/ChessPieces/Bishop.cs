using System;
using System.Collections.Generic;

namespace chess_game.Model.ChessPieces
{
    public class Bishop : ChessPiece
    {
        public Bishop(string color, Position position) : base(color, position) { }

        public override bool IsMoveValid(Position newPosition, ChessBoard board)
        {
            int rowDiff = Math.Abs(newPosition.Row - Position.Row);
            int colDiff = Math.Abs(newPosition.Col - Position.Col);

            if (rowDiff != colDiff)
                return false; // Not a diagonal move

            int rowDirection = newPosition.Row > Position.Row ? 1 : -1;
            int colDirection = newPosition.Col > Position.Col ? 1 : -1;

            int row = Position.Row + rowDirection;
            int col = Position.Col + colDirection;

            // Check if the path is blocked
            while (row != newPosition.Row && col != newPosition.Col)
            {
                if (board.Board[row, col] != null)
                    return false;

                row += rowDirection;
                col += colDirection;
            }

            // Destination is empty or has an opponent's piece
            var target = board.Board[newPosition.Row, newPosition.Col];
            return target == null || target.Color != this.Color;
        }

        public override List<(int, int)> GetValidMoves(ChessPiece[,] board, int row, int col)
        {
            var moves = new List<(int, int)>();
            var directions = new (int, int)[] { (-1, -1), (-1, 1), (1, -1), (1, 1) };

            foreach (var (dr, dc) in directions)
            {
                int newRow = row + dr;
                int newCol = col + dc;

                while (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
                {
                    var target = board[newRow, newCol];

                    if (target == null)
                    {
                        moves.Add((newRow, newCol));
                    }
                    else
                    {
                        if (target.Color != this.Color)
                            moves.Add((newRow, newCol));
                        break; // Blocked
                    }

                    newRow += dr;
                    newCol += dc;
                }
            }

            return moves;
        }
    }
}
