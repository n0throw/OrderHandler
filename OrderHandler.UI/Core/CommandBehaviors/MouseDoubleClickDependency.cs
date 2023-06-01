using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace OrderHandler.UI.Core.CommandBehaviors; 

public class MouseDoubleClick
{
	public static readonly DependencyProperty CommandProperty =
		DependencyProperty.RegisterAttached(
			"Command",
			typeof(ICommand),
			typeof(MouseDoubleClick),
			new UIPropertyMetadata(CommandChanged)
		);

	public static readonly DependencyProperty CommandParameterProperty =
		DependencyProperty.RegisterAttached(
			"CommandParameter",
			typeof(object),
			typeof(MouseDoubleClick),
			new UIPropertyMetadata(null)
		);

	public static void SetCommand(DependencyObject target, ICommand value) =>
		target.SetValue(CommandProperty, value);

	public static void SetCommandParameter(DependencyObject target, object value) =>
		target.SetValue(CommandParameterProperty, value);
	
	public static object GetCommandParameter(DependencyObject target) =>
		target.GetValue(CommandParameterProperty);

	static void CommandChanged(DependencyObject target, DependencyPropertyChangedEventArgs e) {
		if (target is not Control control)
			return;

		switch (e) {
			case { NewValue: not null, OldValue: null }:
				control.MouseDoubleClick += OnMouseDoubleClick;
				break;
			case {NewValue: null, OldValue: not null}:
				control.MouseDoubleClick -= OnMouseDoubleClick;
				break;
		}
	}

	static void OnMouseDoubleClick(object sender, RoutedEventArgs e)
	{
		var control = sender as Control;
		var command = (ICommand)control?.GetValue(CommandProperty)!;
		object? commandParameter = control?.GetValue(CommandParameterProperty);
		command.Execute(commandParameter);
	}
}