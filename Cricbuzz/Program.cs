
using Cricbuzz.Features.MatchTeam;
using Cricbuzz.Interfaces;
using Cricbuzz.Utils;
using MatchType = Cricbuzz.Utils.MatchType;

(ITeam TeamA, ITeam TeamB) SetupTeams()
{
    var TeamA = new Team("TeamA", "CountryA", 1);
    var TeamB = new Team("TeamB", "CountryB", 2);
    for (int i = 1; i <= 11; i++)
    {
        var playerA = new Player(GetPlayerType(i), new Person($"A_PlayerName_{i}", 25 + i));
        var playerB = new Player(GetPlayerType(i), new Person($"B_PlayerName_{i}", 26 + i));
            
        TeamA.PlayingEleven.Enqueue(playerA);
        TeamB.PlayingEleven.Enqueue(playerB);
    }
        
    for (int i = 12; i <= 15; i++)
    {
        var benchPlayerA = new Player(GetPlayerType(i), new Person($"A_BenchPlayerName_{i}", 30 + i));
        var benchPlayerB = new Player(GetPlayerType(i), new Person($"B_BenchPlayerName_{i}", 31 + i));
            
        TeamA.BenchPlayers.Add(benchPlayerA);
        TeamB.BenchPlayers.Add(benchPlayerB);
    }
    
    TeamA.SetupBattingController();
    TeamA.SetupBowlingController();
    TeamB.SetupBattingController();
    TeamB.SetupBowlingController();

    return (TeamA, TeamB);
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

var (teamA, teamB) = SetupTeams();
Console.WriteLine($"Team A: {teamA.Name}, Country: {teamA.Country}, Ranking: {teamA.Ranking}");
Console.WriteLine($"Team B: {teamB.Name}, Country: {teamB.Country}, Ranking: {teamB.Ranking}");
var match = new Cricbuzz.Match();
match.RegisterMatch(teamA, teamB, new DateTime(), "Stadium XYZ", MatchType.ODI);
match.StartMatch();
