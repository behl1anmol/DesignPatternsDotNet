namespace ChainOfResponsibility.CashWithdrawal;

public class FiveHundredRupeeProcessor : CashWithdrawalProcessor
{
    private decimal Balance { get; set; }
    
    public FiveHundredRupeeProcessor(CashWithdrawalProcessor? nextProcessor, decimal balance) 
        : base(nextProcessor)
    {
        Balance = balance;
    }
    public override void ProcessWithdrawal(decimal amount)
    {
        if (amount >= 500 && Balance >= 500)
        {
            var numOfNotes = Math.Min((int)(amount / 500), (int)(Balance / 500));
            var dispensedAmount = numOfNotes * 500;
            amount -= dispensedAmount;
            Balance -= dispensedAmount;
            Console.WriteLine($"Dispensed {numOfNotes} notes of 500. Remaining amount to dispense: {amount}");
        }
        base.ProcessWithdrawal(amount);
    }
}