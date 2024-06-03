using StrategyPattern.Factory;
using StrategyPattern.Models;
using StrategyPattern.Strategies;
using StrategyPattern.Utils;

namespace StrategyPattern;

public class Cart
{
    public Cart(IPaymentStrategyFactory strategyFactory)
    {
        StrategyFactory = strategyFactory;
    }
    public List<Item> Items { get; set; } = new List<Item>();
    public IPaymentStrategyFactory StrategyFactory { get; set; }
    public PaymentMethod PaymentMethod { get; set; }

    public decimal Total => Items.Sum(i => i.Total);

    public bool ProcessPayment() => StrategyFactory.ProcessPayment(this);
    
}