
using Cricbuzz.Features.MatchTeam;
using Cricbuzz.Interfaces;
using Cricbuzz.Utils;
using MatchType = Cricbuzz.Utils.MatchType;

(ITeam TeamA, ITeam TeamB) SetupTeams()
{
    var teamA = new Team("TeamA", "CountryA", 1);
    var teamB = new Team("TeamB", "CountryB", 2);
    for (int i = 1; i <= 11; i++)
    {
        var playerA = new Player(GetPlayerType(i), new Person($"A_PlayerName_{i}", 25 + i));
        var playerB = new Player(GetPlayerType(i), new Person($"B_PlayerName_{i}", 26 + i));
            
        teamA.PlayingEleven.Enqueue(playerA);
        teamB.PlayingEleven.Enqueue(playerB);
    }
        
    for (int i = 12; i <= 15; i++)
    {
        var benchPlayerA = new Player(GetPlayerType(i), new Person($"A_BenchPlayerName_{i}", 30 + i));
        var benchPlayerB = new Player(GetPlayerType(i), new Person($"B_BenchPlayerName_{i}", 31 + i));
            
        teamA.BenchPlayers.Add(benchPlayerA);
        teamB.BenchPlayers.Add(benchPlayerB);
    }
    
    teamA.SetupBattingController();
    teamA.SetupBowlingController();
    teamB.SetupBattingController();
    teamB.SetupBowlingController();

    return (teamA, teamB);
}

PlayerType GetPlayerType(int i)
{
    if(i < 5)
        return PlayerType.Batsman;
    else if(i == 6)
        return PlayerType.AllRounder;
    else
        return PlayerType.Bowler;
}

var (squadA, squadB) = SetupTeams();
Console.WriteLine($"Team A: {squadA.Name}, Country: {squadA.Country}, Ranking: {squadA.Ranking}");
Console.WriteLine($"Team B: {squadB.Name}, Country: {squadB.Country}, Ranking: {squadB.Ranking}");
var match = new Cricbuzz.Match(squadA, squadB, DateTime.Now, "Stadium XYZ", MatchType.ODI);
match.StartMatch();
