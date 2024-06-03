using StrategyPattern.Strategies;
using StrategyPattern.Utils;

namespace StrategyPattern.Factory;

public class PaymentStrategyFactory(IEnumerable<IPaymentStrategy> strategies) : IPaymentStrategyFactory
{
    bool IPaymentStrategyFactory.ProcessPayment(Cart cart)
    {
        return cart.PaymentMethod switch
        {
            PaymentMethod.Cash => strategies.First(s => s.GetType() == typeof(CashPaymentStrategy)).Process(cart.Total),
            PaymentMethod.CreditCard => strategies.First(s => s.GetType() == typeof(CreditCardPaymentStrategy))
                .Process(cart.Total),
            PaymentMethod.DebitCard => strategies.First(s => s.GetType() == typeof(DebitCardPaymentStrategy))
                .Process(cart.Total),
            PaymentMethod.NetBanking => strategies.First(s => s.GetType() == typeof(NetBankingPaymentStrategy))
                .Process(cart.Total),
            _ => throw new Exception("Invalid payment method")
        };
    }
}