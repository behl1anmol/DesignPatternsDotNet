using TicTacToe.Interfaces;
using TicTacToe.Utils;

namespace TicTacToe.Components;

public class Board : IBoard
{
    public int Size { get; set; }
    public IPiece[][] Grid { get; set; }
    private int[][] Row { get; set; }
    private int[][] Column { get; set; }
    private int[] Diagonal { get; set; }
    private int[] AntiDiagonal { get; set; }

    public Board(int size, int players)
    {
        Size = size;
        Grid = new IPiece[size][];
        for (int i = 0; i < size; i++)
        {
            Grid[i] = new IPiece[size];
        }
        //initialize grid with empty pieces
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Grid[i][j] = new PieceE();
            }
        }
        Row = new int[size][];
        for (int i = 0; i < size; i++)
        {
            Row[i] = new int[players];
        }
        Column = new int[size][];
        for (int i = 0; i < size; i++)
        {
            Column[i] = new int[players];
        }
        Diagonal = new int[players];
        AntiDiagonal = new int[players];
    }
    public void AddPiece(int x, int y, IPiece piece)
    {
        Grid[x][y] = piece;
    }

    public int CheckWinner(int x, int y, int playerIndex)
    {
        Row[x][playerIndex]++;
        Column[y][playerIndex]++;
        if (x == y)
        {
            Diagonal[playerIndex]++;
        }
        if (x + y == Size - 1)
        {
            AntiDiagonal[playerIndex]++;
        }
        if (Row[x][playerIndex] == Size || Column[y][playerIndex] == Size ||
            Diagonal[playerIndex] == Size || AntiDiagonal[playerIndex] == Size)
        {
            return playerIndex;
        }
        return -1;
    }

    public bool IsFull()
    {
        foreach (var piece in Grid)
        {
            foreach (var p in piece)
            {
                if (p.Type == PieceType.E)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool IsAlreadyOccupied(int x, int y)
    {
        if(Grid[x][y].Type != PieceType.E)
        {
            return true;
        }
        return false;
    }
    
    public void PrintBoard()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                Console.Write(Grid[i][j].Type + " ");
            }
            Console.WriteLine();
        }
    }
}