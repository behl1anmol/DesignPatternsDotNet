using StrategyPattern.Strategies;
using StrategyPattern.Utils;

namespace StrategyPattern.Factory;

public class PaymentStrategyFactory : IPaymentStrategyFactory
{
    private IEnumerable<IPaymentStrategy> _strategies;
    
    public PaymentStrategyFactory(IEnumerable<IPaymentStrategy> strategies)
    {
        _strategies = strategies;
    }
    bool IPaymentStrategyFactory.ProcessPayment(Cart cart)
    {
        switch (cart.PaymentMethod)
        {
            case PaymentMethod.Cash:
                return _strategies.First(s => s.GetType() == typeof(CashPaymentStrategy)).Process(cart.Total);
                break;
            case PaymentMethod.CreditCard:
                return _strategies.First(s => s.GetType() == typeof(CreditCardPaymentStrategy)).Process(cart.Total);
                break;
            case PaymentMethod.DebitCard:
                break;
            case PaymentMethod.NetBanking:
                break;
            case PaymentMethod.Wallet:
                break;
            case PaymentMethod.UPI:
                break;
            default:
                throw new Exception("Invalid payment method");
        }

        return false;
    }
}