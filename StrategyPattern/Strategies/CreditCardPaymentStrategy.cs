namespace StrategyPattern.Strategies;

public class CreditCardPaymentStrategy : IPaymentStrategy
{
    //private const string CreditCardNumber = "1234-5678-9012-3456";
    //private const string ExpiryDate = "12/24";
    //private const string CVV = "123";
    private const string _gatewayCharges = "2.5%";
    public bool Process(decimal amount)
    {
        Console.WriteLine($"Processing credit card payment of {amount} with gateway charges of {_gatewayCharges}...");
        return true;
    }
}