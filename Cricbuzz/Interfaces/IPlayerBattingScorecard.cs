namespace Cricbuzz.Interfaces;

public interface IPlayerBattingScorecard
{
    int Runs { get; set; }
    int BallsFaced { get; set; }
    int Fours { get; set; }
    int Sixes { get; set; }
    bool IsOut { get; set; }
}