using Cricbuzz.Utils;

namespace Cricbuzz.Interfaces;

public interface IBall
{
    int BallNo { get; set; }
    BallType BType { get; set; }
    RunType RType { get; set; }
    IPlayer PlayedBy { get; set; }
    IPlayer BowledBy { get; set; }
    List<IScoreUpdateObserver> Scores { get; set; }
    //event Action<IPlayer, RunType>? OnBallDelivered;

    RunType DeliverBall(int ballNo, IPlayer bowler, IPlayer striker, IPlayer nonStriker);
    void NotifyScoreUpdate();
}