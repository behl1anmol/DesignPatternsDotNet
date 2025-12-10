using TicTacToe.Interfaces;
using TicTacToe.Utils;

namespace TicTacToe.Components;

public class PieceY : IPiece
{
    public PieceType Type { get; set; }
    public PieceY()
    {
        Type = PieceType.Y;
    }
}