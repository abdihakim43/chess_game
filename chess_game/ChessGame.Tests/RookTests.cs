using chess_game.Model;
using chess_game.Model.ChessPieces;
using NUnit.Framework;

namespace ChessGame.Tests
{
    [TestFixture]
    public class RookTests
    {
        private ChessBoard board;

        [SetUp]
        public void Setup()
        {
            board = new ChessBoard();
            board.Board = new ChessPiece[8, 8]; // Start with empty board
        }

        [Test]
        public void Rook_CanMoveVertically()
        {
            var rook = new Rook("White", new Position(4, 4));
            board.Board[4, 4] = rook;

            var target = new Position(1, 4); // vertical move
            bool isValid = rook.IsMoveValid(target, board);

            Assert.IsTrue(isValid);
        }

        [Test]
        public void Rook_CanMoveHorizontally()
        {
            var rook = new Rook("White", new Position(4, 4));
            board.Board[4, 4] = rook;

            var target = new Position(4, 7); // horizontal move
            bool isValid = rook.IsMoveValid(target, board);

            Assert.IsTrue(isValid);
        }

        [Test]
        public void Rook_CannotMoveDiagonally()
        {
            var rook = new Rook("White", new Position(4, 4));
            board.Board[4, 4] = rook;

            var target = new Position(6, 6); // diagonal move
            bool isValid = rook.IsMoveValid(target, board);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void Rook_CannotJumpOverPieces()
        {
            var rook = new Rook("White", new Position(4, 4));
            board.Board[4, 4] = rook;

            var blocker = new Pawn("White", new Position(3, 4));
            board.Board[3, 4] = blocker;

            var target = new Position(2, 4); // trying to jump over pawn
            bool isValid = rook.IsMoveValid(target, board);

            Assert.IsFalse(isValid);
        }
    }
}
