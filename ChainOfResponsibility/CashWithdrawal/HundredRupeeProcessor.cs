namespace ChainOfResponsibility.CashWithdrawal;

public class HundredRupeeProcessor : CashWithdrawalProcessor
{
    private decimal Balance { get; set; }
    
    public HundredRupeeProcessor(CashWithdrawalProcessor? nextProcessor, decimal balance) 
        : base(nextProcessor)
    {
        Balance = balance;
    }
    public override void ProcessWithdrawal(decimal amount)
    {
        if (amount >= 100 && Balance >= 100)
        {
            var numOfNotes = Math.Min((int)(amount / 100), (int)(Balance / 100));
            var dispensedAmount = numOfNotes * 100;
            amount -= dispensedAmount;
            Balance -= dispensedAmount;
            Console.WriteLine($"Dispensed {numOfNotes} notes of 100. Remaining amount to dispense: {amount}");
        }
        base.ProcessWithdrawal(amount);
    }
}