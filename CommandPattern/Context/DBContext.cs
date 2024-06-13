using CommandPattern.Enums;
using CommandPattern.Models;

namespace CommandPattern.Context;
public class DbContext
{
    private List<TransactionEntity> Transactions { get; set; } = new();
    
    public List<TransactionEntity> SelectAll()
    {
        return Transactions;
    }
    
    public TransactionEntity? SelectById(Guid id)
    {
        return Transactions.FirstOrDefault(x => x.Id == id) ?? null;
    }
    
    public void Delete(Guid id)
    {
        var transaction = Transactions.FirstOrDefault(x => x.Id == id);
        if (transaction == null) return;
        Transactions.Remove(transaction);
        if (transaction.ReverseTransactionId.HasValue)
        {
            var reverseTransaction = Transactions.FirstOrDefault(x => x.Id == transaction.ReverseTransactionId);
            if (reverseTransaction != null)
            {
                Transactions.Remove(reverseTransaction);
            }
        }
    }
    
    public TransactionEntity? Save(TransactionEntity transactionEntity)
    {
        var existingTransaction = Transactions.FirstOrDefault(x => x.Id == transactionEntity.Id);
        if (existingTransaction == null)
        {
            transactionEntity.Id = Guid.NewGuid();
            transactionEntity.State = TransactionState.Open;
            Transactions.Add(transactionEntity);
            return SelectById(transactionEntity.Id);
        }
        else
        {
            existingTransaction.State = TransactionState.Closed;
            existingTransaction.Amount = transactionEntity.Amount;
            return existingTransaction;
        }
    }
    
    public TransactionEntity? Reverse(TransactionEntity transactionEntity)
    {
        var reverseTransaction = new TransactionEntity
        {
            Id = Guid.NewGuid(),
            Amount = transactionEntity.Amount * -1,
            ReverseTransactionId = transactionEntity.Id
        };
        transactionEntity.State = TransactionState.Closed;
        return Save(reverseTransaction);
    }
}