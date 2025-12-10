using TicTacToe.Interfaces;
using TicTacToe.Utils;

namespace TicTacToe.Components;

public class PieceX : IPiece
{
    public PieceType Type { get; set; }
    public PieceX()
    {
        Type = PieceType.X;
    }
}