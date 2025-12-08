using Cricbuzz.Interfaces;
using Cricbuzz.Utils;

namespace Cricbuzz.Features.Innings;

public class Over : IOver
{
    public Over(int overNumber)
    {
        OverNumber = overNumber;
        Balls = new List<IBall>();
    }

    public int OverNumber { get; set; }
    public List<IBall> Balls { get; set; }
    public bool IsCompleted { get; set; }
    public event Func<IPlayer,IPlayer>?  OnPlayerOut; 

    public void StartOver(IPlayer bowler, ref IPlayer striker, ref IPlayer nonStriker)
    {
        //assume only striker cannot get out by a bowler in an over
        int legalDeliveries = 0;
        int currDelivery = 1;
        var ballType = BallType.NormalBall; //need to set on the basis of type of match
        while (legalDeliveries < 6)
        {
            var ball = new Ball(ballType);
            Balls.Add(ball);
            var rType = ball.DeliverBall(currDelivery++, bowler, striker, nonStriker);
            if (rType != RunType.Wide && rType != RunType.NoBall)
            {
                legalDeliveries++;
            }

            if (rType == RunType.Single || rType == RunType.Triple)
            {
                (striker, nonStriker) = (nonStriker, striker);
            }
            
            //we can also say non striker is out because isout flag is set by score updater on player
            if (rType == RunType.Out)
            {
                striker = OnPlayerOut?.Invoke(striker) ?? throw new Exception("No handler for OnPlayerOut event");
            }
        }
        IsCompleted = true;
    }
    
}