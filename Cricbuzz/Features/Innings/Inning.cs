using Cricbuzz.Interfaces;
using Cricbuzz.Utils;

namespace Cricbuzz.Features.Innings;

public class Inning : IInning
{
    public Inning(ITeam battingTeam, ITeam bowlingTeam, int overSize)
    {
        BattingTeam = battingTeam;
        BowlingTeam = bowlingTeam;
        Overs = new IOver[overSize];
        for (int i = 0; i < overSize; i++)
        {
            Overs[i] = new Over(i + 1);
        }
    }
    public ITeam BattingTeam { get; }
    public ITeam BowlingTeam { get; }
    public IOver[] Overs { get; }
    
    public void StartInning()
    {
        var bowler = BowlingTeam.BowlingController.CurrentBowler;
        // Implementation to start the inning
        //need to handle when batsman gets out and bowler changes??
        Console.WriteLine("Starting Overs for " + BattingTeam.Name);
        foreach(var over in Overs)
        {
            Console.WriteLine($"Starting Over {over.OverNumber}");
            var striker = BattingTeam.BattingController.Striker;
            var nonStriker = BattingTeam.BattingController.NonStriker;
            
            Console.WriteLine($"Current Striker: {striker.Person.Name}, Non-Striker: {nonStriker.Person.Name}, Bowler: {bowler.Person.Name}");
            // Play each over
            over.StartOver(bowler, ref striker, ref nonStriker);
            
            BattingTeam.SwapStriker();
            bowler = BowlingTeam.BowlingController.GetNextBowler();
        }
        BattingTeam.OversPlayed = Overs.Count(o => o.IsCompleted);
    }
    

}