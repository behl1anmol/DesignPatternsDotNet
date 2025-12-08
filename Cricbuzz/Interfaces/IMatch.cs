using Cricbuzz.Utils;

namespace Cricbuzz.Interfaces;
using MatchType = Cricbuzz.Utils.MatchType;

public interface IMatch
{
    ITeam TeamA { get; }
    ITeam TeamB { get; }
    DateTime MatchDate { get; }
    string Venue { get; }
    MatchType TypeOfMatch { get; }
    IInning[] Innings { get; }
    ITeam? Winner { get; }
    (ITeam,InningChoice)  TossWinner { get; }

    void RegisterMatch(ITeam a, ITeam b, DateTime matchDate, string venue, MatchType matchType);
    void StartMatch();
}