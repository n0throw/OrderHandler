#region System_Using
using System;
using System.Windows.Input;
#endregion System_Using

#region OrderHandler_Using
#endregion OrderHandler_Using

namespace OrderHandler.UI.Core;

internal class RelayCommand : ICommand
{
    private readonly Action<object?> execute;
    private readonly Func<object?, bool> canExecute;

    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public RelayCommand(Action<object?> execute, Func<object?, bool> canExecute)
    {
        this.execute = execute;
        this.canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
        => canExecute == null || canExecute(parameter);

    public void Execute(object? parameter)
        => execute(parameter);
}