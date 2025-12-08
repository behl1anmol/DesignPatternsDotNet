namespace Cricbuzz.Interfaces;

public interface IOver
{
    int OverNumber { get; set; }
    List<IBall> Balls { get; set; }
    bool IsCompleted { get; set; }
    event Func<IPlayer, IPlayer>? OnPlayerOut;
    void StartOver(IPlayer bowler, ref IPlayer striker, ref IPlayer nonStriker);
}