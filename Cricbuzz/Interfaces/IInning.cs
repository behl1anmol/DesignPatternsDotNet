namespace Cricbuzz.Interfaces;

public interface IInning
{
    ITeam BattingTeam { get; }
    ITeam BowlingTeam { get; }
    public IOver[] Overs { get; }
    void StartInning();
}