namespace CommandPattern.Commands;

public interface ICommand
{ 
    bool Execute(object parameter);
    bool CanExecute(object parameter);
    void Undo();
}