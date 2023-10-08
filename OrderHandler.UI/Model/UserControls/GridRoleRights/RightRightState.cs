using System;

using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.UserControls.GridRoleRights; 

public class RightRightState : BasePropertyChanger, IComparable {
	string _name;
	public string Name {
		get => _name;
		set {
			_name = value;
			OnPropertyChanged();
		}
	}

	public readonly RightRightStates CurrentState;

	public RightRightState(string name, RightRightStates state) {
		_name = name;
		CurrentState = state;
	}

	public int CompareTo(object? obj) {
		if (obj is RightRightState state)
			return CurrentState.CompareTo(state.CurrentState);

		throw new ArgumentException("Err");
	}

	public override string ToString() => Name;
}