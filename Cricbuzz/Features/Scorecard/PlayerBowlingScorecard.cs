using Cricbuzz.Interfaces;

namespace Cricbuzz.Features.Scorecard;

public class PlayerBowlingScorecard : IPlayerBowlingScorecard
{
    public int OversBowled
    {
        get => BallsBowled / 6;
    }
    public int Maidens { get; set; }
    public int RunsConceded { get; set; }
    public int WicketsTaken { get; set; }
    public int NoBalls { get; set; }
    public int Wides { get; set; }
    public int BallsBowled { get; set; }
    public int Extras
    {
        get => NoBalls + Wides;
    }
    
    public PlayerBowlingScorecard()
    {
        Maidens = 0;
        RunsConceded = 0;
        WicketsTaken = 0;
        NoBalls = 0;
        Wides = 0;
        BallsBowled = 0;
    }
}