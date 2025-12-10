using TicTacToe.Components;

namespace TicTacToe.Interfaces;

public interface IGame
{
    List<Player> Players { get; }   
    IBoard Board { get; }
    Player? IsWinner { get; }
    
    void StartGame();
    void SetupGame();
}