namespace Cricbuzz.Interfaces;

public interface IPlayerBowlingController
{
    Queue<IPlayer> BowlingOrder { get; }
    IPlayer CurrentBowler { get; }
    Dictionary<IPlayer, int> OversBowled { get; }
    public int BowlingOversLimit { get; set; }
    IPlayer GetCurrentBowler();
    IPlayer GetNextBowler();
    void Setup(IReadOnlyList<IPlayer> players);
}