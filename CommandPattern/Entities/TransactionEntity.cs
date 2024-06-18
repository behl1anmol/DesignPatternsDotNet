using CommandPattern.Enums;

namespace CommandPattern.Models;

public class TransactionEntity
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public Guid? ReverseTransactionId { get; set; }
    
    public  TransactionState State { get; set; }
}