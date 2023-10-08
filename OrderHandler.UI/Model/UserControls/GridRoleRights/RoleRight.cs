using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using OrderHandler.UI.Contexts.UserControls;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.UserControls.GridRoleRights; 

public class RoleRight : BasePropertyChanger {
	string _name;
	public string Name {
		get => _name;
		set {
			_name = value;
			OnPropertyChanged();
		}
	}

	RightRightState? _currentSelection;
	public RightRightState? CurrentSelection {
		get => _currentSelection;
		set {
			_currentSelection = value;
			OnPropertyChanged();
		}
	}

	public ObservableCollection<RightRightState> States { get; }

	public RoleRight(string name, IEnumerable<RightRightState> states) {
		_name = name;
		States = new(states.OrderBy(s => s));
		// todo тут CurrentSelect из БД
	}
}