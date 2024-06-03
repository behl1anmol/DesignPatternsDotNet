namespace StrategyPattern.Strategies;

public class CashPaymentStrategy : IPaymentStrategy
{
    public bool Process(decimal amount)
    {
        Console.WriteLine("Processing cash payment for amount INR. {0}", amount);
        return true;
    }
}