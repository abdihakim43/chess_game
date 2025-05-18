using chess_game.Model;
using chess_game.Model.ChessPieces;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using Path = System.IO.Path;
using chess_game.View;

namespace chess_game
{
    public partial class MainWindow : Window
    {
        private ChessPiece selectedPiece;
        private int selectedRow = -1;
        private int selectedCol = -1;
        private ChessBoard chessBoard;
        private string gameMode; // 👈 Added: store PvP or PvE mode

        public MainWindow(string mode)
        {
            InitializeComponent();
            gameMode = mode; // 👈 store selected mode

            chessBoard = new ChessBoard();
            chessBoard.InitializeBoard();
            chessBoard.CheckmateOccurred += OnCheckmateOccurred;
            DrawPieces();
        }

        private void OnCheckmateOccurred(string winner)
        {
            var winnerWindow = new WinnerWindow(winner);
            winnerWindow.ShowDialog();
        }

        // 2. Update BoardGrid_Click to call BotMakeMove with await
        private async void BoardGrid_Click(object sender, MouseButtonEventArgs e)
        {
            ClearHighlights();

            if (e.OriginalSource is FrameworkElement clickedElement)
            {
                int row = Grid.GetRow(clickedElement) - 1;
                int col = Grid.GetColumn(clickedElement) - 1;

                if (row >= 0 && row < 8 && col >= 0 && col < 8)
                {
                    var clickedPosition = new Position(row, col);

                    if (selectedPiece == null)
                    {
                        var piece = chessBoard.Board[row, col];
                        if (piece != null && piece.Color == chessBoard.CurrentPlayer)
                        {
                            selectedPiece = piece;
                            selectedRow = row;
                            selectedCol = col;
                            HighlightMoves(piece, row, col);
                        }
                    }
                    else
                    {
                        var fromPosition = new Position(selectedRow, selectedCol);

                        if (chessBoard.TryMovePiece(fromPosition, clickedPosition))
                        {
                            AnimateMove(fromPosition, clickedPosition);
                            CheckForPawnPromotion(clickedPosition);

                            ClearHighlights();
                            selectedPiece = null;

                            // If PvE and it's now the bot's turn
                            if (gameMode == "PvE" && chessBoard.CurrentPlayer == "Black")
                            {
                                await BotMakeMove(); // <-- Await the async method
                            }
                            return;
                        }

                        ClearHighlights();
                        selectedPiece = null;
                    }
                }
            }
        }

        // In MainWindow.xaml.cs

        // 1. Update BotMakeMove to async Task
        private async Task BotMakeMove()
        {
            await Task.Delay(1500); // Wait 1.5 seconds before making the move

            // 🧠 Simple bot: pick first valid move
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    var piece = chessBoard.Board[r, c];
                    if (piece != null && piece.Color == "Black")
                    {
                        var moves = piece.GetValidMoves(chessBoard.Board, r, c);
                        foreach (var move in moves)
                        {
                            Position from = new Position(r, c);
                            Position to = new Position(move.Item1, move.Item2);

                            if (chessBoard.TryMovePiece(from, to))
                            {
                                AnimateMove(from, to);
                                CheckForPawnPromotion(to);
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void AnimateMove(Position from, Position to)
        {
            var image = boardGrid.Children
                .OfType<Image>()
                .FirstOrDefault(img => Grid.GetRow(img) == from.Row + 1 && Grid.GetColumn(img) == from.Col + 1);

            if (image == null)
            {
                DrawPieces(); // fallback
                return;
            }

            double cellSize = 60;
            double deltaX = (to.Col - from.Col) * cellSize;
            double deltaY = (to.Row - from.Row) * cellSize;

            var transform = new TranslateTransform();
            image.RenderTransform = transform;

            var animX = new DoubleAnimation(0, deltaX, TimeSpan.FromMilliseconds(800));
            var animY = new DoubleAnimation(0, deltaY, TimeSpan.FromMilliseconds(800));
            animX.FillBehavior = FillBehavior.Stop;
            animY.FillBehavior = FillBehavior.Stop;

            animY.Completed += (s, e) => DrawPieces();

            transform.BeginAnimation(TranslateTransform.XProperty, animX);
            transform.BeginAnimation(TranslateTransform.YProperty, animY);
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

        private string GetPieceImagePath(ChessPiece piece)
        {
            string colorPrefix = piece.Color == "White" ? "w" : "b";
            string pieceSuffix = piece switch
            {
                Pawn => "p",
                Rook => "r",
                Knight => "n",
                Bishop => "b",
                Queen => "q",
                King => "k",
                _ => ""
            };

            string exePath = AppContext.BaseDirectory;
            string imageFolder = Path.Combine(exePath, "Images", "gothic");
            return Path.Combine(imageFolder, $"{colorPrefix}{pieceSuffix}.png");
        }

        private void DrawPieces()
        {
            var oldImages = boardGrid.Children.OfType<Image>().ToList();
            foreach (var img in oldImages)
            {
                boardGrid.Children.Remove(img);
            }

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    var piece = chessBoard.Board[row, col];
                    if (piece != null)
                    {
                        string imagePath = GetPieceImagePath(piece);
                        if (!File.Exists(imagePath)) continue;

                        var image = new Image
                        {
                            Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute)),
                            Width = 50,
                            Height = 50,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center
                        };

                        Grid.SetRow(image, row + 1);
                        Grid.SetColumn(image, col + 1);
                        Panel.SetZIndex(image, 1);

                        boardGrid.Children.Add(image);
                    }
                }
            }
        }

        public void ResetGame()
        {
            chessBoard.InitializeBoard();
            DrawPieces();
        }

        private void OnPawnPromotion(Position pawnPosition)
        {
            string pawnColor = chessBoard.Board[pawnPosition.Row, pawnPosition.Col].Color;
            PawnConverterWindow pawnConverterWindow = new PawnConverterWindow(chessBoard, pawnPosition, pawnColor)
            {
                Owner = this
            };
            pawnConverterWindow.ShowDialog();
            DrawPieces();
        }

        private void CheckForPawnPromotion(Position to)
        {
            ChessPiece piece = chessBoard.Board[to.Row, to.Col];
            if (piece is Pawn && ((piece.Color == "White" && to.Row == 0) || (piece.Color == "Black" && to.Row == 7)))
            {
                OnPawnPromotion(to);
            }
        }

        public bool TryMovePiece(Position from, Position to)
        {
            if (chessBoard.IsMoveValid(chessBoard.Board[from.Row, from.Col], to))
            {
                chessBoard.Board[to.Row, to.Col] = chessBoard.Board[from.Row, from.Col];
                chessBoard.Board[from.Row, from.Col] = null;
                chessBoard.Board[to.Row, to.Col].Position = to;
                CheckForPawnPromotion(to);
                return true;
            }
            return false;
        }
    }
}
