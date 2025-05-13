using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess_game.Model.ChessPieces;

namespace chess_game.Model
{
    [TestFixture]
    public class TestKingsideCastlingWhite
    {
        [Test]
        public void TestKingsideCastling()
        {
            // Arrange
            var board = new ChessBoard();
            board.InitializeBoard();

            // Clear any pieces blocking kingside castling
            board.Board[7, 5] = null; // f1
            board.Board[7, 6] = null; // g1

            // Ensure both king and rook have not moved
            var king = board.Board[7, 4] as King;
            var rook = board.Board[7, 7] as Rook;
            king.HasMoved = false;
            rook.HasMoved = false;

            // Act
            var success = board.TryMovePiece(new Position(7, 4), new Position(7, 6));

            // Assert
            Assert.IsTrue(success, "Kingside castling should succeed.");
            Assert.IsInstanceOf<King>(board.Board[7, 6], "King should be at g1 (7,6).");
            Assert.IsInstanceOf<Rook>(board.Board[7, 5], "Rook should be at f1 (7,5).");
            Assert.IsNull(board.Board[7, 4], "King's original position (e1) should be empty.");
            Assert.IsNull(board.Board[7, 7], "Rook's original position (h1) should be empty.");
        }
    }
}
