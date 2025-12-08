namespace Cricbuzz.Interfaces;

public interface ITeam
{
    string Name { get; set; }
    string Country { get; set; }
    int Ranking { get; set; }
    Queue<IPlayer> PlayingEleven { get;}
    List<IPlayer> BenchPlayers { get; }
    IPlayerBattingController BattingController { get; }
    IPlayerBowlingController BowlingController { get; }
    int TotalRuns { get; }
    int OversPlayed { get; set; }
    int Extras { get; }
    int WicketsLost { get; }
    
    IPlayer? GetNextStriker();
    IPlayer GetNextBowler();
    void SwapStriker();
    void SetupBattingController();
    void SetupBowlingController();
}