using CommandPattern.Enums;
using CommandPattern.Models;
using CommandPattern.Repository;

namespace CommandPattern.Commands;

public class SaveTransactionCommand : ICommand
{
    private readonly IRepository _transactionRepository;
    private TransactionEntity? _transactionEntity;

    public SaveTransactionCommand(IRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public bool Execute(object parameter)
    {
        _transactionEntity = _transactionRepository.SaveTransaction((TransactionEntity)parameter);
        return true;
    }

    public bool CanExecute(object parameter)
    {
        var entity = parameter as TransactionEntity;
        return entity.State is TransactionState.New or TransactionState.Open;
    }

    public void Undo()
    {
        if (_transactionEntity is null)
        {
            Console.WriteLine("No Transaction to undo");
        }
        _transactionRepository.ReverseTransaction(_transactionEntity);
    }
    
    
}