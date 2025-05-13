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
        private ChessPiece selectedPiece;
        private int selectedRow = -1;
        private int selectedCol = -1;

        private ChessBoard chessBoard;

        public MainWindow()
        {
            InitializeComponent();

            // Create and initialize the board
            chessBoard = new ChessBoard();
            chessBoard.InitializeBoard();
            chessBoard.CheckmateOccurred += OnCheckmateOccurred; // Subscribe to the event
            DrawPieces();
        }
        private void OnCheckmateOccurred(string winner)
        {
            // Create and display the WinnerWindow
            var winnerWindow = new chess_game.View.WinnerWindow(winner);
            winnerWindow.ShowDialog(); // Show the window as a modal dialog
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
            // Clear previous highlights
            ClearHighlights();

            var clickedElement = e.OriginalSource as FrameworkElement;
            if (clickedElement != null)
            {
                int row = Grid.GetRow(clickedElement) - 1;
                int col = Grid.GetColumn(clickedElement) - 1;

                if (row >= 0 && row < 8 && col >= 0 && col < 8)
                {
                    var clickedPosition = new Position(row, col);

                    if (selectedPiece == null)
                    {
                        // Selecting a piece
                        var piece = chessBoard.Board[row, col];
                        if (piece != null && piece.Color == chessBoard.CurrentPlayer) // Only allow selecting the current player's pieces
                        {
                            selectedPiece = piece;
                            selectedRow = row;
                            selectedCol = col;

                            HighlightMoves(piece, row, col);
                        }
                    }
                    else
                    {
                        // Attempt to move the piece
                        var fromPosition = new Position(selectedRow, selectedCol);




                        // Handle normal moves
                        if (chessBoard.TryMovePiece(fromPosition, clickedPosition))
                        {
                            DrawPieces(); // Redraw the board after a successful move
                        }

                        ClearHighlights();
                        selectedPiece = null;
                    }
                }
            }
        }

        private void HighlightMoves(ChessPiece piece, int row, int col)
        {
            var moves = piece.GetValidMoves(chessBoard.Board, row, col);
            foreach (var move in moves)
            {
                int targetRow = move.Item1;
                int targetCol = move.Item2;

                var border = boardGrid.Children
                    .OfType<Border>()
                    .FirstOrDefault(b => Grid.GetRow(b) == targetRow + 1 && Grid.GetColumn(b) == targetCol + 1);

                if (border != null)
                {
                    border.Background = new SolidColorBrush(Colors.Yellow);
                }
            }
        }


        private void ClearHighlights()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    var border = boardGrid.Children
                        .OfType<Border>()
                        .FirstOrDefault(b => Grid.GetRow(b) == row + 1 && Grid.GetColumn(b) == col + 1);

                    if (border != null)
                    {
                        bool isDark = (row + col) % 2 == 0;
                        border.Background = new SolidColorBrush(isDark ? Color.FromRgb(184, 139, 74) : Color.FromRgb(227, 193, 111));
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
        public void ResetGame()
        {
            // Clear the board, reset pieces, and start a new game

            chessBoard.InitializeBoard();
            DrawPieces();
        }

    }
}