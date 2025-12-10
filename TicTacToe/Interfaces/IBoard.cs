namespace TicTacToe.Interfaces;

public interface IBoard
{
    int Size { get; }
    IPiece[][] Grid { get; }
    
    void AddPiece(int x, int y, IPiece piece);
    bool IsFull();
    bool IsAlreadyOccupied(int x, int y);
    int CheckWinner(int x, int y, int playerIndex);
    void PrintBoard();
}