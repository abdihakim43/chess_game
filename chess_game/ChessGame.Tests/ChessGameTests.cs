// Test 
using chess_game.Model;
using chess_game.Model.ChessPieces;

namespace ChessGame.Tests
{
    [TestFixture]
    public class PawnTests
    {
        private ChessBoard board;

        [SetUp]
        public void Setup()
        {
            board = new ChessBoard();
            board.InitializeBoard(); // Set up the initial chessboard
        }

        [Test]
        public void TestPawnMoveOneStepForward()
        {
            // Arrange: White pawn at (6, 0)
            var pawn = board.Board[6, 0]; // White pawn at (6, 0)
            var targetPosition = new Position(5, 0); // Move to (5, 0)

            // Act
            var result = pawn.IsMoveValid(targetPosition, board); // Validate move

            // Assert
            Assert.IsTrue(result, "White pawn should be able to move one step forward.");
        }

        [Test]
        public void TestPawnFirstMoveTwoStepsForward()
        {
            // Arrange: White pawn at (6, 0)
            var pawn = board.Board[6, 0]; // White pawn at (6, 0)
            var targetPosition = new Position(4, 0); // Move to (4, 0)

            // Act
            var result = pawn.IsMoveValid(targetPosition, board); // Validate move

            // Assert
            Assert.IsTrue(result, "White pawn should be able to move two steps forward on its first move.");
        }

        [Test]
        public void TestPawnBlockedMove()
        {
            // Arrange: White pawn at (6, 0), and a blocking piece at (5, 0)
            var pawn = board.Board[6, 0]; // White pawn at (6, 0)
            var blockingPiece = new Rook("Black", new Position(5, 0));
            board.Board[5, 0] = blockingPiece; // Place a Black rook at (5, 0)

            var targetPosition = new Position(5, 0); // Try moving to (5, 0)

            // Act
            var result = pawn.IsMoveValid(targetPosition, board); // Validate move

            // Assert
            Assert.IsFalse(result, "Pawn should not be able to move to a square occupied by another piece.");
        }

        [Test]
        public void TestPawnCaptureMove()
        {
            // Arrange: White pawn at (6, 1) and Black pawn at (5, 2)
            var whitePawn = new Pawn("White", new Position(6, 1)); // White pawn at (6, 1) (row 6, col 1 corresponds to a2)
            var blackPawn = new Pawn("Black", new Position(5, 2)); // Black pawn at (5, 2) (row 5, col 2 corresponds to b3)

            board.Board[6, 1] = whitePawn; // Place white pawn at (6, 1)
            board.Board[5, 2] = blackPawn; // Place black pawn at (5, 2)

            var targetPosition = new Position(5, 2); // Target position for the white pawn to capture the black pawn

            // Act
            var result = whitePawn.IsMoveValid(targetPosition, board); // Check if the move is valid

            // Assert
            Assert.IsTrue(result, "White pawn should be able to capture the Black pawn diagonally at (5, 2).");
        }




        [Test]
        public void TestPawnInvalidDiagonalMoveWithoutCapture()
        {
            // Arrange: White pawn at (6, 0)
            var pawn = board.Board[6, 0]; // White pawn at (6, 0)
            var targetPosition = new Position(5, 1); // Invalid diagonal move

            // Act
            var result = pawn.IsMoveValid(targetPosition, board); // Validate move

            // Assert
            Assert.IsFalse(result, "Pawn should not be able to move diagonally without capturing.");
        }

        [Test]
        public void TestPawnMoveBackwards()
        {
            // Arrange: White pawn at (6, 0)
            var pawn = board.Board[6, 0]; // White pawn at (6, 0)
            var targetPosition = new Position(7, 0); // Try moving backwards

            // Act
            var result = pawn.IsMoveValid(targetPosition, board); // Validate move

            // Assert
            Assert.IsFalse(result, "Pawn should not be able to move backwards.");
        }
    }
}