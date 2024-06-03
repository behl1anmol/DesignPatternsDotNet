namespace StrategyPattern.Strategies;

public interface IPaymentStrategy
{
    bool Process(decimal amount);
}