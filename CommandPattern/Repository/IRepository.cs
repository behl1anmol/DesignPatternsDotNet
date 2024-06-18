using CommandPattern.Models;

namespace CommandPattern.Repository;

public interface IRepository
{
    
    List<TransactionEntity> GetTransactions();
    TransactionEntity? GetTransaction(Guid id);
    void RemoveTransaction(Guid id);
    TransactionEntity? SaveTransaction(TransactionEntity transactionEntity);
    void ReverseTransaction(TransactionEntity transactionEntity);
}