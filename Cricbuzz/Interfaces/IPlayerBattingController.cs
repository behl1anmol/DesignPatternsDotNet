namespace Cricbuzz.Interfaces;

public interface IPlayerBattingController
{
    Queue<IPlayer> BattingOrder { get; }
    IPlayer Striker { get; }
    IPlayer NonStriker { get; }
    
    IPlayer GetNextStriker();
    IPlayer SwapStriker();
    IPlayer GetCurrentStriker();
    IPlayer GetCurrentNonStriker();
    void Setup(IReadOnlyList<IPlayer> players);
}