using CommandPattern.Context;
using CommandPattern.Models;

namespace CommandPattern.Repository;

public class TransactionRepository : IRepository
{
    private readonly ILogger<TransactionRepository> _logger;
    private readonly DbContext _dbContext;
    
    public TransactionRepository(ILogger<TransactionRepository> logger, DbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
    
    public List<TransactionEntity> GetTransactions()
    {
        _logger.LogInformation("Getting all transactions");
        return _dbContext.SelectAll();
    }
    
    public TransactionEntity? GetTransaction(Guid id)
    {
        _logger.LogInformation($"Getting transaction with id: {id}");
        return _dbContext.SelectById(id);
    }
    
    public void RemoveTransaction(Guid id)
    {
        _logger.LogInformation($"Removing transaction with id: {id}");
        _dbContext.Delete(id);
    }
    
    public TransactionEntity? SaveTransaction(TransactionEntity transactionEntity)
    {
        _logger.LogInformation($"Saving transaction");
        var savedEntity = _dbContext.Save(transactionEntity);
        if (savedEntity == null)
        {
            _logger.LogError("Failed to save transaction");
        }
        else
        {
            Console.WriteLine($"Saved Transaction with id: {savedEntity.Id}");
            Console.WriteLine($"Transaction Amount: {savedEntity.Amount}");
            Console.WriteLine($"Transaction State: {savedEntity.State}");
        }

        return savedEntity;
    }
    
    public void ReverseTransaction(TransactionEntity transactionEntity)
    {
        _logger.LogInformation($"Reversing transaction with id: {transactionEntity.Id}");
        var rev = _dbContext.Reverse(transactionEntity);
        
        if (rev == null)
        {
            _logger.LogError("Failed to reverse transaction");
        }
        else
        {
            Console.WriteLine($"Reversed Transaction with id: {rev.Id}");
            Console.WriteLine($"Transaction Amount: {rev.Amount}");
            Console.WriteLine($"Transaction State: {rev.State}");
            Console.WriteLine($"Transaction Reversed against id: {rev.ReverseTransactionId}");
        }
    }
}