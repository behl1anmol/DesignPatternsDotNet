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
            case RunType.Out:
                bowlingScorecard.WicketsTaken += 1;
                break;
        }
        Console.WriteLine("{0,-20} | R:{1,3}  Wd:{2,2}  Nb:{3,2}  W:{4,2}",
            bowledBy.Person.Name,
            bowlingScorecard.RunsConceded,
            bowlingScorecard.Wides,
            bowlingScorecard.NoBalls,
            bowlingScorecard.WicketsTaken);
    }
}