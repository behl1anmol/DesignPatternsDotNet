namespace StrategyPattern.Strategies;

public class DebitCardPaymentStrategy : IPaymentStrategy
{
    private const decimal GatewayCharges = 1.5M;
    public bool Process(decimal amount)
    {
        Console.WriteLine($"Gateway charges: {GatewayCharges}%");
        Console.WriteLine($"Processing debit card payment for amount INR. {amount + amount * GatewayCharges / 100}");
        return true;
    }
}