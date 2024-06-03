namespace StrategyPattern.Factory;

public interface IPaymentStrategyFactory
{
    bool ProcessPayment(Cart cart);
}