using Cricbuzz.Interfaces;
using Cricbuzz.Utils;

namespace Cricbuzz.Features.Scorecard;

public class BowlingScorecardObserver : IScoreUpdateObserver
{
    public void UpdateScore(IPlayer playedBy, IPlayer bowledBy, RunType runType)
    {
        var bowlingScorecard = bowledBy.PlayerBowlingScorecard;

        switch (runType)
        {
            case RunType.Wide:
                bowlingScorecard.Wides += 1;
                break;
            case RunType.NoBall:
                bowlingScorecard.NoBalls += 1;
                break;
            case RunType.LegBye:
                bowlingScorecard.RunsConceded += 1;
                break;
            case RunType.Single:
                bowlingScorecard.RunsConceded += 1;
                break;
            case RunType.Double:
                bowlingScorecard.RunsConceded += 2;
                break;
            case RunType.Triple:
                bowlingScorecard.RunsConceded += 3;
                break;
            case RunType.Four:
                bowlingScorecard.RunsConceded += 4;
                break;
            case RunType.Six:
                bowlingScorecard.RunsConceded += 6;
                break;
        }
        
    }
}