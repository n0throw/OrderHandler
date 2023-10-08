using System;

using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model; 

public class DBCombo : MainPagePropertyChanger, ICloneable {
	string _displayName;
	string _systemName;

	public DBCombo(long id, string? displayName, string? systemName) {
		Id = id;
		_displayName = displayName ?? string.Empty;
		_systemName = systemName ?? string.Empty;
	}
	
	public long Id { get; }
	
	public string DisplayName {
		get => _displayName;
		set {
			_displayName = value;
			OnPropertyChanged();
		}
	}
	
	public string SystemName {
		get => _systemName;
		set {
			_systemName = value;
			OnPropertyChanged();
		}
	}
	
	public object Clone() => new DBCombo(Id, _displayName, _systemName);

	public override bool Equals(object? obj) {
		if (obj is DBCombo dbCombo)
			return Equals(dbCombo);
        
		return false;
	}

	bool Equals(DBCombo other) => 
		GetHashCode() == other.GetHashCode() && 
		_displayName == other._displayName && 
		_systemName == other._systemName;

	public override int GetHashCode() => Id.GetHashCode();
}