namespace StrategyPattern.Strategies;

public class CashPaymentStrategy : IPaymentStrategy
{
    public bool Process(decimal amount)
    {
        Console.WriteLine("Processing cash payment...");
        return true;
    }
}