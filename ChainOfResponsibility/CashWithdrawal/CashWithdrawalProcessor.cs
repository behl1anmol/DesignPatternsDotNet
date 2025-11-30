namespace ChainOfResponsibility.CashWithdrawal;

public abstract class CashWithdrawalProcessor
{
    private CashWithdrawalProcessor? NextProcessor { get; init; }
    
    protected CashWithdrawalProcessor(CashWithdrawalProcessor? nextProcessor = null)
    {
        NextProcessor = nextProcessor;
    }

    public virtual void ProcessWithdrawal(decimal amount)
    {
        if(NextProcessor == null && !DispenseCompleted(amount))
            Console.WriteLine("Cannot process the requested amount with available denominations.");
        else if(DispenseCompleted(amount))
            Console.WriteLine("Dispensed amount with available denominations.");
        else
            NextProcessor?.ProcessWithdrawal(amount);
    }

    protected bool DispenseCompleted(decimal amount) => amount == 0m;
}