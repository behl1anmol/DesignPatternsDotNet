using Cricbuzz.Interfaces;
using Cricbuzz.Utils;

namespace Cricbuzz.Features.Scorecard;

public class PlayerBattingScorecard : IPlayerBattingScorecard
{
    public int Runs { get; set; }
    public int BallsFaced { get; set; }
    public int Fours { get; set; }
    public int Sixes { get; set; }
    public bool IsOut { get; set; }
    
    public PlayerBattingScorecard()
    {
        Runs = 0;
        BallsFaced = 0;
        Fours = 0;
        Sixes = 0;
        IsOut = false;
    }
}