
using System.IO;
using chess_game;
using chess_game.Model;
using chess_game.Model.ChessPieces;
using NUnit.Framework;

namespace ChessGame.Tests
{
    [TestFixture]
    public class ChessGameIntegrationTests
    {
        [Test]
        public void AllPieceImages_ShouldExistInGothicFolder()
        {
            // Arrange
            var mainWindow = new MainWindow();
            var testPieces = new ChessPiece[]
            {
                new Pawn("White", null),
                new Pawn("Black", null),
                new Rook("White", null),
                new Rook("Black", null),
                new Knight("White", null),
                new Knight("Black", null),
                new Bishop("White", null),
                new Bishop("Black", null),
                new Queen("White", null),
                new Queen("Black", null),
                new King("White", null),
                new King("Black", null)
            };

            // Act & Assert
            foreach (var piece in testPieces)
            {
                string imagePath = typeof(MainWindow)
                    .GetMethod("GetPieceImagePath", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    .Invoke(mainWindow, new object[] { piece }) as string;

                Assert.IsTrue(File.Exists(imagePath), $"Image not found: {imagePath}");
            }
        }
    }
}
