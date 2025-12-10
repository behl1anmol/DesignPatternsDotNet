using TicTacToe.Interfaces;
using TicTacToe.Utils;

namespace TicTacToe.Components;

public class PieceE : IPiece
{
    public PieceType Type { get; }
    public PieceE()
    {
        Type = PieceType.E;
    }
}