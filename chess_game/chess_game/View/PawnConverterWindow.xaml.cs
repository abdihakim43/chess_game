using System.Windows;
using System.Windows.Controls;
using chess_game.Model;
using chess_game.Model.ChessPieces;

namespace chess_game.View
{
    public partial class PawnConverterWindow : Window
    {
        private readonly ChessBoard chessBoard;
        private readonly Position pawnPosition;
        private readonly string pawnColor;

        public PawnConverterWindow(ChessBoard chessBoard, Position pawnPosition, string pawnColor)
        {
            InitializeComponent();
            this.chessBoard = chessBoard;
            this.pawnPosition = pawnPosition;
            this.pawnColor = pawnColor;
        }

        // Button click event wired in XAML: Click="ConvertPawnButton_Click"
        private void ConvertPawnButton_Click(object sender, RoutedEventArgs e)
        {
            if (PieceComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedPiece = selectedItem.Content.ToString();

                ChessPiece newPiece = selectedPiece switch
                {
                    "Queen" => new Queen(pawnColor, pawnPosition),
                    "Rook" => new Rook(pawnColor, pawnPosition),
                    "Bishop" => new Bishop(pawnColor, pawnPosition),
                    "Knight" => new Knight(pawnColor, pawnPosition),
                    _ => null
                };

                if (newPiece != null)
                {
                    chessBoard.Board[pawnPosition.Row, pawnPosition.Col] = newPiece;
                    this.Close(); // Close the promotion window after successful conversion
                }
            }
            else
            {
                MessageBox.Show("Please select a piece to convert to.", "Invalid Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
