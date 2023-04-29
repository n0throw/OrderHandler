﻿using System;
using System.Windows.Input;

namespace OrderHandler.UI.Core;

public class RelayCommand : ICommand {
	readonly Action<object?> _execute;
	readonly Func<object?, bool>? _canExecute;

	public event EventHandler? CanExecuteChanged {
		add => CommandManager.RequerySuggested += value;
		remove => CommandManager.RequerySuggested -= value;
	}

	public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute) {
		_execute = execute;
		_canExecute = canExecute;
	}

	public bool CanExecute(object? parameter) =>
		_canExecute == null || _canExecute(parameter);

	public void Execute(object? parameter) =>
		_execute(parameter);
}