using Cricbuzz.Features.Scorecard;
using Cricbuzz.Interfaces;
using Cricbuzz.Utils;

namespace Cricbuzz.Features.Innings;

public class Ball : IBall
{
    public Ball(BallType bType)
    {
        BType = bType;
        Scores = new List<IScoreUpdateObserver>();
        Scores.Add(new BattingScorecardObserver());
        Scores.Add(new BowlingScorecardObserver());
    }
    public int BallNo { get; set; }
    public BallType BType { get; set; }
    public RunType RType { get; set; }
    public IPlayer PlayedBy { get; set; }
    public IPlayer BowledBy { get; set; }
    public IPlayer NonStriker { get; set; }
    public List<IScoreUpdateObserver> Scores { get; set; }
    //public event Action<IPlayer, RunType>? OnBallDelivered;

    public RunType DeliverBall(int ballNo, IPlayer bowler, IPlayer striker, IPlayer nonStriker)
    {
        var random = new Random();
        var randValue = random.Next(0, 8);
        var rType = (RunType)randValue;
        
        BallNo = ballNo;
        BowledBy = bowler;
        PlayedBy = striker;
        NonStriker = nonStriker;
        RType = rType;
        NotifyScoreUpdate();

        return RType;
    }

    public void NotifyScoreUpdate()
    {
        foreach (var score in Scores)
        {
            score.UpdateScore(PlayedBy, BowledBy, RType);
        }
    }
}