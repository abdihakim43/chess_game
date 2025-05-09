using chess_game.Model;

public abstract class ChessPiece
{
    public string Color { get; set; }
    public Position Position { get; set; }

    public ChessPiece(string color, Position position)
    {
        Color = color;
        Position = position;
    }

    // Each piece must define how it validates a move
    public abstract bool IsMoveValid(Position newPosition, ChessBoard board);

    // Each piece can override this to return its list of valid moves
    public virtual List<(int, int)> GetValidMoves(ChessPiece[,] board, int row, int col)
    {
        return new List<(int, int)>();
    }
}
