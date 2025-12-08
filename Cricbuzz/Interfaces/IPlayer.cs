using Cricbuzz.Utils;

namespace Cricbuzz.Interfaces;

public interface IPlayer
{
    PlayerType Type { get; set; }
    IPerson Person { get; set; }
    IPlayerBattingScorecard PlayerBattingScorecard { get; set; }
    IPlayerBowlingScorecard PlayerBowlingScorecard { get; set; }
}