namespace Cricbuzz.Interfaces;

public interface IPlayerBowlingScorecard
{
    int OversBowled { get; }
    int Maidens { get; set; }
    int RunsConceded { get; set; }
    int WicketsTaken { get; set; }
    int NoBalls { get; set; }
    int Wides { get; set; }
    int Extras { get; }
}