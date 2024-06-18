using CommandPattern.Commands;
using CommandPattern.Enums;
using CommandPattern.Manager;
using CommandPattern.Models;
using CommandPattern.Repository;

namespace CommandPattern;

public class Application
{
    private readonly ICommand _saveTransactionCommand;
    private readonly CommandManager _commandManager;
    private readonly ILogger<Application> _logger;
    
    public Application(ICommand command, CommandManager commandManager, ILogger<Application> logger)
    {
        _saveTransactionCommand = command;
        _commandManager = commandManager;
        _logger = logger;
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

        //_logger.LogInformation("Saving transaction");
        //_commandManager.Invoke(_saveTransactionCommand, transaction);
        
        _logger.LogInformation("Waiting for 5 seconds");
        Thread.Sleep(5000);
        
        _logger.LogInformation("Undoing transaction");
        _commandManager.Undo();
        _logger.LogInformation("Transaction undone");
    }
}