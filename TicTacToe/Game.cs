using TicTacToe.Components;
using TicTacToe.Interfaces;

namespace TicTacToe;

public class Game :IGame
{
    public List<Player> Players { get; set; } = new();
    public IBoard Board { get; private set; } = new Components.Board(3,2);
    public Player? IsWinner { get; set; } = null;

    public void StartGame()
    {
        int chance = 0;
        while (Board.IsFull() == false && IsWinner == null)
        {
            Player currentPlayer = Players[chance % Players.Count];
            int x = 0; 
            int y = 0; 
            Console.WriteLine($"Please enter the X coordinate for {currentPlayer.Name}'s move:");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Please enter the Y coordinate for {currentPlayer.Name}'s move:");
            y = Convert.ToInt32(Console.ReadLine());
            while (Board.IsAlreadyOccupied(x, y))
            {
                Console.WriteLine("This position is already occupied. Please choose another position.");
                Console.WriteLine($"Please enter the X coordinate for {currentPlayer.Name}'s move:");
                x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Please enter the Y coordinate for {currentPlayer.Name}'s move:");
                y = Convert.ToInt32(Console.ReadLine());
            }

            Board.AddPiece(x, y, currentPlayer.PlayingPiece);
            Board.PrintBoard();
            int winnerIndex = Board.CheckWinner(x, y, chance % Players.Count);
            if (winnerIndex != -1)
            {
                IsWinner = Players[winnerIndex];
                Console.WriteLine($"Congratulations {IsWinner.Name}, you have won the game!");
                break;
            }
            chance++;
        }
        if (IsWinner == null)
        {
            Console.WriteLine("The game is a draw!");
        }
    }

    public void SetupGame()
    {
        Console.WriteLine("Welcome to Tic Tac Toe!");
        var numberOfPlayers = 2;
        for (int i = 1; i <= numberOfPlayers; i++)
        {
            Console.WriteLine($"Enter name for Player {i}:");
            string playerName = Console.ReadLine() ?? $"Player{i}";
            IPiece playingPiece = i == 1 ? new Components.PieceX() : new Components.PieceY();
            Players.Add(new Components.Player(playerName, playingPiece));
        }
        Console.WriteLine("Enter the size of the board (e.g., 3 for a 3x3 board):");
        var boardSize = Convert.ToInt32(Console.ReadLine());
        Board = new Board(boardSize, numberOfPlayers);
        
        Console.WriteLine("Game setup complete. Let's start the game!");
    }
}