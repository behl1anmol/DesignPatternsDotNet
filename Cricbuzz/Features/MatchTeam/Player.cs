using Cricbuzz.Interfaces;
using Cricbuzz.Utils;

namespace Cricbuzz.Features.MatchTeam;

public class Player : IPlayer
{
    public Player(PlayerType type, IPerson person)
    {
        Id = Guid.NewGuid();
        Type = type;
        Person = person;
        PlayerBattingScorecard = new Features.Scorecard.PlayerBattingScorecard();
        PlayerBowlingScorecard = new Features.Scorecard.PlayerBowlingScorecard();
    }
    public Guid Id { get; set; }
    public PlayerType Type { get; set; }
    public IPerson Person { get; set; }
    public IPlayerBattingScorecard PlayerBattingScorecard { get; set; }
    public IPlayerBowlingScorecard PlayerBowlingScorecard { get; set; }
}