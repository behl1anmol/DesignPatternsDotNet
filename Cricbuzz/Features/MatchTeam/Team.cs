using System.Collections.Immutable;
using Cricbuzz.Features.Controllers;
using Cricbuzz.Interfaces;
using Cricbuzz.Utils;

namespace Cricbuzz.Features.MatchTeam;

public class Team : ITeam
{
    public string Name { get; set; }
    public string Country { get; set; }
    public int Ranking { get; set; }
    public Queue<IPlayer> PlayingEleven { get; set; }
    public List<IPlayer> BenchPlayers { get; set; }
    public IPlayerBattingController BattingController { get; set; }
    public IPlayerBowlingController BowlingController { get; set; }
    public int Extras => PlayingEleven.Sum(player => player.PlayerBowlingScorecard.Extras);
    public int TotalRuns => PlayingEleven.Sum(player => player.PlayerBattingScorecard.Runs);
    public int WicketsLost => PlayingEleven.Sum(player => player.PlayerBattingScorecard.IsOut ? 1 : 0);
    public int OversPlayed { get; set; }
    public bool AllOut => WicketsLost == 10;

    public Team(string name, string country, int ranking)
    {
        Name = name;
        Country = country;
        Ranking = ranking;
        PlayingEleven = new Queue<IPlayer>();
        BenchPlayers = new List<IPlayer>();
        BattingController = new PlayerBattingController();
        BowlingController = new PlayerBowlingController();
        
    }
    
    public IPlayer? GetNextStriker()
    {
        if (BattingController == null)
        {
            throw new Exception("BattingController is null");
        }
        return BattingController.GetNextStriker();
    }

    public void SwapStriker()
    {
        if (BattingController == null)
        {
            throw new Exception("BattingController is null");
        }
        BattingController.SwapStriker();
    }
    
    public IPlayer GetNextBowler()
    {
        if (BowlingController == null)
        {
            throw new Exception("BowlingController is null");
        }
        return BowlingController.GetNextBowler();
    }
    
    public void SetupBattingController()
    {
        var sorted = PlayingEleven.OrderBy(p =>
        {
            switch (p.Type)
            {
                case PlayerType.Batsman: return 0;
                case PlayerType.AllRounder: return 1;
                case PlayerType.Bowler: return 2;
                default: return 3;
            }
        }).ToList();

        BattingController.Setup(sorted);
    }
    
    public void SetupBowlingController()
    {
        var sorted = PlayingEleven.OrderBy(p =>
        {
            switch (p.Type)
            {
                case PlayerType.Bowler: return 0;
                case PlayerType.AllRounder: return 1;
                case PlayerType.Batsman: return 2;
                default: return 3;
            }
        }).ToList();

        BowlingController.Setup(sorted);
    }
}