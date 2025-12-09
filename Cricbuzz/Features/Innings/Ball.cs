using Cricbuzz.Features.Scorecard;
using Cricbuzz.Interfaces;
using Cricbuzz.Utils;

namespace Cricbuzz.Features.Innings;

public class Ball : IBall
{
    private static readonly Random random = new Random();
    
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
        var randValue = random.Next(0, 10);
        var rType = (RunType)randValue;
        
        
        BallNo = ballNo;
        BowledBy = bowler;
        PlayedBy = striker;
        NonStriker = nonStriker;
        RType = rType;
        
        Display();
        NotifyScoreUpdate();

        return RType;
    }

    private void Display()
    {
        var previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Blue;
        
        if (BallNo == 1)
        {
            Console.WriteLine("{0,-6} | {1,-20} | {2,-20} | {3,-7} | {4,-20}", "Ball", "Bowler", "Batsman", "Runs", "NonStriker");
            Console.WriteLine(new string('-', 80));
        }
    
        Console.WriteLine("{0,-6} | {1,-20} | {2,-20} | {3,-7} | {4,-20}",
            $"#{BallNo}",
            BowledBy.Person.Name,
            PlayedBy.Person.Name,
            RType,
            NonStriker.Person.Name);
    
        Console.ForegroundColor = previousColor;
    }

    public void NotifyScoreUpdate()
    {
        var previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        foreach (var score in Scores)
        {
            score.UpdateScore(PlayedBy, BowledBy, RType);
        }
        Console.ForegroundColor = previousColor;
    }
}