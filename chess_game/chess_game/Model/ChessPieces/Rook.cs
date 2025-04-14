using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            // Check if the move is in the same row or same column
            if (currentRow != targetRow && currentCol != targetCol)
            {
                return false; // Invalid move for rook
            }

            // Determine movement direction
            int rowDirection = targetRow == currentRow ? 0 : (targetRow > currentRow ? 1 : -1);
            int colDirection = targetCol == currentCol ? 0 : (targetCol > currentCol ? 1 : -1);

            // Step through the path between current and target position
            int checkRow = currentRow + rowDirection;
            int checkCol = currentCol + colDirection;

            while (checkRow != targetRow || checkCol != targetCol)
            {
                if (board.Board[checkRow, checkCol] != null)
                {
                    return false; // Path is blocked
                }

                checkRow += rowDirection;
                checkCol += colDirection;
            }

            // Check if the target square is empty or has an enemy ChessPiece
            ChessPiece targetPiece = board.Board[targetRow, targetCol];
            return targetPiece == null || targetPiece.Color != this.Color;
        }
    }

}

