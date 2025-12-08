using Cricbuzz.Interfaces;
using Cricbuzz.Utils;

namespace Cricbuzz.Features.Scorecard;

public class BattingScorecardObserver : IScoreUpdateObserver
{
    public void UpdateScore(IPlayer playedBy, IPlayer bowledBy, RunType runType)
    {
        var battingScorecard = playedBy.PlayerBattingScorecard;
        battingScorecard.BallsFaced += 1;

        switch (runType)
        {
            case RunType.Single:
                battingScorecard.Runs += 1;
                break;
            case RunType.Double:
                battingScorecard.Runs += 2;
                break;
            case RunType.Triple:
                battingScorecard.Runs += 3;
                break;
            case RunType.Four:
                battingScorecard.Runs += 4;
                battingScorecard.Fours += 1;
                break;
            case RunType.Six:
                battingScorecard.Runs += 6;
                battingScorecard.Sixes += 1;
                break;
        }
    }
}