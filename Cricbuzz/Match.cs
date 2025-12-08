using Cricbuzz.Features.Innings;
using Cricbuzz.Features.MatchTeam;
using Cricbuzz.Interfaces;
using Cricbuzz.Utils;
using MatchType = Cricbuzz.Utils.MatchType;

namespace Cricbuzz;

public class Match : IMatch
{
    public ITeam TeamA { get; set; }
    public ITeam TeamB { get; set; }
    public DateTime MatchDate { get; set; }
    public string Venue { get; set; }
    public MatchType TypeOfMatch { get; set; } //need to include max over allowed
    public IInning[] Innings { get; set; }
    public ITeam? Winner { get; set; } //can be a tiw therefore nullable
    public (ITeam, InningChoice) TossWinner { get; set; }

    public void RegisterMatch(ITeam a, ITeam b, DateTime matchDate, string venue, MatchType matchType)
    {
        TeamA = a;
        TeamB = b;
        MatchDate = matchDate;
        Venue = venue;
        TypeOfMatch = matchType;
        SetupInnings();
    }

    public void StartMatch()
    {
        Console.WriteLine($"Setting Up Innings");
        SetupInnings();
        Console.WriteLine($"Tossing the coin");
        Toss();
        Console.WriteLine($"Toss won by {TossWinner.Item1.Name}, elected to {TossWinner.Item2.ToString()}");
        // Further implementation to start the match
        foreach(var inning in Innings)
        {
            Console.WriteLine($"Starting inning: {inning.BattingTeam.Name} vs {inning.BowlingTeam.Name}");
            inning.StartInning();
            //print the team score, overs played, wickets lost
            Console.WriteLine($"{inning.BattingTeam.Name} scored {inning.BattingTeam.TotalRuns} runs for {inning.BattingTeam.WicketsLost} wickets in {inning.BattingTeam.OversPlayed} overs.");
        }
        
        if(TeamA.TotalRuns > TeamB.TotalRuns)
        {
            Winner = TeamA;
        }
        else if(TeamB.TotalRuns > TeamA.TotalRuns)
        {
            Winner = TeamB;
        }
        else
        {
            Winner = null; // Match is a tie
        }
        
        if(Winner != null)
        {
            Console.WriteLine($"Match won by {Winner.Name}");
        }
        else
        {
            Console.WriteLine("Match is a tie");
        }
    }

    private void SetupInnings()
    {
        var battingTeam = TossWinner.Item2 == InningChoice.Batting ? TossWinner.Item1 : (TossWinner.Item1 == TeamA ? TeamB : TeamA);
        var bowlingTeam = battingTeam == TeamA ? TeamB : TeamA;
        if (this.TypeOfMatch == Cricbuzz.Utils.MatchType.ODI)
        {
            this.Innings = new IInning[2];
            this.Innings[0] = new Inning(battingTeam, bowlingTeam, 50);
            this.Innings[1] = new Inning(battingTeam, bowlingTeam,50);
        }
        else
        {
            this.Innings = new IInning[2];
            this.Innings[0] = new Inning(battingTeam, bowlingTeam, 20);
            this.Innings[1] = new Inning(battingTeam, bowlingTeam,20);
        }
    }

    private void Toss()
    {
        var random = new Random();
        var winner = random.Next(0, 2) == 0 ? TeamA : TeamB;
        var choice = random.Next(0, 2) == 0 ? InningChoice.Batting : InningChoice.Bowling;
        TossWinner = (winner, choice);
    }
}