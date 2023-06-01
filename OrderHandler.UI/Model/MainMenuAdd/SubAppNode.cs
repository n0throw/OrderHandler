using System.Collections.ObjectModel;

using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.MainMenuAdd; 

public class SubAppNode : PropertyChanger {
	int _id;
	int _idParent;
	string _name;
	bool _isSelected;
	bool _isExpanded;

	public SubAppNode() {
		Childrens = new();
	}

	public ObservableCollection<SubAppNode> Childrens { get; set; }
	
	public string? SubAppPageName { get; set; }
	
	public int Id {
		get => _id;
		set {
			_id = value;
			OnPropertyChanged();
		}
	}
	public int IdParent {
		get => _idParent;
		set {
			_idParent = value;
			OnPropertyChanged();
		}
	}
	public string Name {
		get => _name;
		set {
			_name = value;
			OnPropertyChanged();
		}
	}
	
	public bool IsSelected {
		get => _isSelected;
		set {
			_isSelected = value;
			if (_isSelected && SubAppPageName is not null)
				GoToPage(SubAppPageName);
				
			OnPropertyChanged();
		}
	}
 
	public bool IsExpanded {
		get => _isExpanded;
		set {
			_isExpanded = value;
			OnPropertyChanged();
		}
	}
}