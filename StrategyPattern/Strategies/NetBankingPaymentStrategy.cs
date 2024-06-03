namespace StrategyPattern.Strategies;

public class NetBankingPaymentStrategy : IPaymentStrategy
{
    public bool Process(decimal amount)
    {
        Console.WriteLine($"Processing net banking payment for amount INR. {amount}");
        return true;
    }
}