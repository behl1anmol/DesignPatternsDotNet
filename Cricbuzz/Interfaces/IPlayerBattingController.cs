namespace Cricbuzz.Interfaces;

public interface IPlayerBattingController
{
    Queue<IPlayer> BattingOrder { get; }
    IPlayer Striker { get; }
    IPlayer NonStriker { get; }

    void SetStrikers(IPlayer striker, IPlayer nonStriker);
    IPlayer GetNextStriker();
    IPlayer SwapStriker();
    IPlayer GetCurrentStriker();
    IPlayer GetCurrentNonStriker();
    void Setup(IReadOnlyList<IPlayer> players);
}