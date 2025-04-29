using chess_game.Model.ChessPieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_game.Model
{
    public class ChessBoard
    {
        public ChessPiece[,] Board { get; set; } // 8x8 array of pieces
        public ChessBoard() // the coonstructor to create a 8x8 grid 
        {
            Board = new ChessPiece[8, 8];

        }

        public void InitializeBoard()
        {
            // clear the board
            Board = new ChessPiece[8, 8];

            // place black pawns (row 1)
            for (int col = 0; col < 8; col++)
            {
                Board[1, col] = new Pawn("Black", new Position(1, col));
            }

            // place white pawns (row 6)
            for (int col = 0; col < 8; col++)
            {
                Board[6, col] = new Pawn("White", new Position(6, col));
            }

            // place black rooks
            Board[0, 0] = new Rook("Black", new Position(0, 0));
            Board[0, 7] = new Rook("Black", new Position(0, 7));

            // place white rooks
            Board[7, 0] = new Rook("White", new Position(7, 0));
            Board[7, 7] = new Rook("White", new Position(7, 7));

            // place knights
            Board[0, 1] = new Knight("Black", new Position(0, 1));
            Board[0, 6] = new Knight("Black", new Position(0, 6));
            Board[7, 1] = new Knight("White", new Position(7, 1));
            Board[7, 6] = new Knight("White", new Position(7, 6));

            // place bishops
            Board[0, 2] = new Bishop("Black", new Position(0, 2));
            Board[0, 5] = new Bishop("Black", new Position(0, 5));
            Board[7, 2] = new Bishop("White", new Position(7, 2));
            Board[7, 5] = new Bishop("White", new Position(7, 5));

            // place queens
            Board[0, 3] = new Queen("Black", new Position(0, 3));
            Board[7, 3] = new Queen("White", new Position(7, 3));

            // place kings
            Board[0, 4] = new King("Black", new Position(0, 4));
            Board[7, 4] = new King("White", new Position(7, 4));
        }


        public bool IsMoveValid(ChessPiece piece, Position newPosition) // a simple method which returns a bool T/F if it's a valid move.
        {
            return piece.IsMoveValid(newPosition, this); 
        }
    }
}
