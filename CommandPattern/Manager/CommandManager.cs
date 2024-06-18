using System.Collections.Concurrent;
using CommandPattern.Commands;
using CommandPattern.Models;

namespace CommandPattern.Manager;

public class CommandManager
{
    private ConcurrentStack<ICommand> Manager { get; } = new();
    
    public void Invoke(ICommand command, TransactionEntity transactionEntity)
    {
        if (!command.CanExecute(transactionEntity)) return;
        Manager.Push(command);
        command.Execute(transactionEntity);
    }
    
    public void Undo()
    {
        if (Manager.TryPop(out var command))
        {
            command.Undo();
        }
    }
    
}