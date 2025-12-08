using Cricbuzz.Interfaces;

namespace Cricbuzz.Features.Controllers;

public class PlayerBattingController : IPlayerBattingController
{
    public Queue<IPlayer> BattingOrder { get; set; }
    public IPlayer Striker { get; set; }
    public IPlayer NonStriker { get; set; }
    public IPlayer GetNextStriker()
    {
        if (BattingOrder.Count == 0)
        {
            //instead of throwing exception check all out
            throw new InvalidOperationException("No more batsmen available in the batting order.");
        }
        return BattingOrder.Dequeue();
    }

    public IPlayer SwapStriker()
    {
        (Striker, NonStriker) = (NonStriker, Striker);
        return Striker;
    }

    public IPlayer GetCurrentStriker()
    {
        return Striker;
    }
    
    public IPlayer GetCurrentNonStriker()
    {
        return NonStriker;
    }

    public void Setup(IReadOnlyList<IPlayer> players)
    {
        BattingOrder = new Queue<IPlayer>(players);
        Striker = BattingOrder.Dequeue();
        NonStriker = BattingOrder.Dequeue();
    }
}