using chess_game.Model.ChessPieces;
using chess_game.Model;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Media3D;

namespace chess_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ChessBoard chessBoard;

        public MainWindow()
        {
            InitializeComponent();



            // create and initialize the board 
            chessBoard = new ChessBoard();
            chessBoard.InitializeBoard();
            DrawPieces();
        }

        private string GetPieceSymbol(ChessPiece piece)
        {
            return piece switch
            {
                Pawn p when p.Color == "White" => "♙",
                Pawn p when p.Color == "Black" => "♟",
                Rook r when r.Color == "White" => "♖",
                Rook r when r.Color == "Black" => "♜",
                Knight k when k.Color == "White" => "♘",
                Knight k when k.Color == "Black" => "♞",
                Bishop b when b.Color == "White" => "♗",
                Bishop b when b.Color == "Black" => "♝",
                Queen q when q.Color == "White" => "♕",
                Queen q when q.Color == "Black" => "♛",
                King k when k.Color == "White" => "♔",
                King k when k.Color == "Black" => "♚",
                _ => ""
            };
        }


        private void BoardGrid_Click(object sender, MouseButtonEventArgs e)
        {
            // Get the clicked element
            var clickedElement = e.OriginalSource as FrameworkElement;

            if (clickedElement != null)
            {
                // Get the row and column of the clicked element
                int row = Grid.GetRow(clickedElement) - 1; // Adjust for grid labels (if any)
                int column = Grid.GetColumn(clickedElement) - 1; // Adjust for grid labels (if any)

                // Ensure the click is within the board bounds
                if (row >= 0 && row < 8 && column >= 0 && column < 8)
                {
                    // Check if there is a chess piece at the clicked position
                    var piece = chessBoard.Board[row, column];
                    if (piece != null)
                    {
                        // Find the Border element at the clicked position
                        var clickedBorder = boardGrid.Children
                            .OfType<Border>()
                            .FirstOrDefault(b => Grid.GetRow(b) == row + 1 && Grid.GetColumn(b) == column + 1);

                        if (clickedBorder != null)
                        {
                            // Change the background color of the clicked cell to red
                            clickedBorder.Background = new SolidColorBrush(Colors.Red);

                            // Optional: Display a message box to confirm the click
                            MessageBox.Show($"Clicked on Row: {row}, Column: {column}, Piece: {piece.GetType().Name}");
                        }
                    }
                }
            }
        }
        private void DrawPieces()
        {
            // Remove old UI elements if needed (optional)
            var toRemove = boardGrid.Children.OfType<TextBlock>().Where(tb => Grid.GetRow(tb) > 0 && Grid.GetRow(tb) < 9).ToList();
            foreach (var item in toRemove)
            {
                boardGrid.Children.Remove(item);
            }

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    var piece = chessBoard.Board[row, col];
                    if (piece != null)
                    {
                        var pieceSymbol = GetPieceSymbol(piece);

                        var textBlock = new TextBlock
                        {
                            Text = pieceSymbol,
                            FontSize = 36,
                            FontWeight = FontWeights.Bold,
                            Foreground = piece.Color == "White" ? Brushes.White : Brushes.Black,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center
                        };

                        // Account for labels and border offset (your actual board starts at Grid.Row=1, Grid.Column=1)
                        Grid.SetRow(textBlock, row + 1);
                        Grid.SetColumn(textBlock, col + 1);
                        boardGrid.Children.Add(textBlock);
                    }
                }
            }
        }

    }
}