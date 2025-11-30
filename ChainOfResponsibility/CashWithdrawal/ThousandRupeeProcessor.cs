namespace ChainOfResponsibility.CashWithdrawal;

public class ThousandRupeeProcessor : CashWithdrawalProcessor
{
    private decimal Balance { get; set; }
    
    public ThousandRupeeProcessor(CashWithdrawalProcessor? nextProcessor, decimal balance) 
        : base(nextProcessor)
    {
        Balance = balance;
    }

    public override void ProcessWithdrawal(decimal amount)
    {
        if (amount >= 1000 && Balance >= 1000)
        {
            var numOfNotes = Math.Min((int)(amount / 1000), (int)(Balance / 1000));
            var dispensedAmount = numOfNotes * 1000;
            amount -= dispensedAmount;
            Balance -= dispensedAmount;
            Console.WriteLine($"Dispensed {numOfNotes} notes of 1000. Remaining amount to dispense: {amount}");
        }
        base.ProcessWithdrawal(amount);
    }
}