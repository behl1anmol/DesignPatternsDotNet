using CommandPattern.Commands;
using CommandPattern.Enums;
using CommandPattern.Manager;
using CommandPattern.Models;
using CommandPattern.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CommandPattern;

public class Application
{
    private readonly ICommand _saveTransactionCommand;
    private readonly CommandManager _commandManager;
    private readonly ILogger<Application> _logger;
    private readonly IServiceProvider _serviceProvider;
    
    public Application(ICommand command, 
        CommandManager commandManager, 
        ILogger<Application> logger, IServiceProvider serviceProvider)
    {
        _saveTransactionCommand = command;
        _commandManager = commandManager;
        _logger = logger;
        _serviceProvider = serviceProvider;
    }
    public void RunAsync()
    {
        var transaction = new TransactionEntity
        {
            Amount = 100,
            State = TransactionState.New
        };
        //print summary of transaction console.writeline
        Console.WriteLine($"Transaction Amount: {transaction.Amount}");
        Console.WriteLine($"Transaction State: {transaction.State}");
        
        _commandManager.Invoke(_saveTransactionCommand, transaction);
        _logger.LogInformation("Transaction created");
        
        _logger.LogInformation("Waiting for 5 seconds");
        Thread.Sleep(5000);

        var transactionRepository = _serviceProvider.GetRequiredService<IRepository>();
        var transactions = transactionRepository.GetTransactions();
        
        //print all transactions
        Console.WriteLine("Transactions:");
        foreach (var trans in transactions)
        {
            Console.WriteLine($"Transaction Amount: {trans.Amount}");
            Console.WriteLine($"Transaction State: {trans.State}");
        }
        
        _logger.LogInformation("Waiting for 5 seconds");
        Thread.Sleep(5000);
        
        _logger.LogInformation("Undoing transaction");
        _commandManager.Undo();
        _logger.LogInformation("Transaction undone");
    }
}