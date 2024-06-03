namespace StrategyPattern.Strategies;

public class CreditCardPaymentStrategy : IPaymentStrategy
{
    private const decimal GatewayCharges = 2.5M;
    public bool Process(decimal amount)
    {
        Console.WriteLine($"Gateway charges: {GatewayCharges}%");
        Console.WriteLine($"Processing credit card payment of {amount + amount * GatewayCharges / 100}");
        return true;
    }
}