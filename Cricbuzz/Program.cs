
using Cricbuzz.Features.MatchTeam;
using Cricbuzz.Interfaces;
using Cricbuzz.Utils;
using MatchType = Cricbuzz.Utils.MatchType;

(ITeam TeamA, ITeam TeamB) SetupTeams(MatchType type)
{
    var teamA = new Team("TeamA", "CountryA", 1, type==MatchType.ODI ?10:4);
    var teamB = new Team("TeamB", "CountryB", 2, type==MatchType.ODI ?10:4);
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
var random = new Random();
var matchType = random.Next(0, 2) == 0 ? MatchType.ODI : MatchType.T20;
Console.WriteLine($"Match Type Selected: {matchType}");
var (squadA, squadB) = SetupTeams(matchType);
Console.WriteLine($"Team A: {squadA.Name}, Country: {squadA.Country}, Ranking: {squadA.Ranking}");
Console.WriteLine($"Team B: {squadB.Name}, Country: {squadB.Country}, Ranking: {squadB.Ranking}");
var match = new Cricbuzz.Match(squadA, squadB, DateTime.Now, "Stadium XYZ", matchType);
match.StartMatch();
