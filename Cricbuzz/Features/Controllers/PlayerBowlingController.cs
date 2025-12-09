using Cricbuzz.Interfaces;

namespace Cricbuzz.Features.Controllers;

public class PlayerBowlingController:IPlayerBowlingController
{
    public PlayerBowlingController(int bowlingOversLimit = 10)
    {
        BowlingOrder = new Queue<IPlayer>();
        OversBowled = new Dictionary<IPlayer, int>();
        BowlingOversLimit = bowlingOversLimit;
    }
    public Queue<IPlayer> BowlingOrder { get; set; }
    public IPlayer CurrentBowler { get; set; }
    public Dictionary<IPlayer, int> OversBowled { get; set; }
    public int BowlingOversLimit { get; set; }
    public IPlayer GetCurrentBowler()
    {
        return CurrentBowler;
    }
    
    private void UpdateCurrentBowlerOvers()
    {
        if (!OversBowled.TryAdd(CurrentBowler, 1))
        {
            OversBowled[CurrentBowler]++;
        }
    }
    
    public IPlayer GetNextBowler()
    {
        if (BowlingOrder.Count == 0)
        {
            throw new InvalidOperationException("No bowlers available in the bowling order.");
        }
        UpdateCurrentBowlerOvers();
        
        BowlingOrder.Enqueue(CurrentBowler);
        CurrentBowler = BowlingOrder.Dequeue();
        while(OversBowled.ContainsKey(CurrentBowler) && OversBowled[CurrentBowler] > BowlingOversLimit)
        {
            if (BowlingOrder.Count == 0)
            {
                throw new InvalidOperationException("No bowlers available within the overs limit.");
            }
            CurrentBowler = BowlingOrder.Dequeue();
        }
        return CurrentBowler;
    }

    public void Setup(IReadOnlyList<IPlayer> players)
    {
        BowlingOrder = new Queue<IPlayer>(players);
        CurrentBowler = BowlingOrder.Dequeue();
    }
}