using System.Collections.ObjectModel;

using OrderHandler.UI.Core;
using OrderHandler.UI.Model;

namespace OrderHandler.UI.Contexts.Windows; 

public class DBConnectSettingsWindowContext : PropertyChanger {
	DBCombo _currentSelection;
	readonly DBCombo _defaultDBCombo = new(-1, "Выберите БД", "None");
    
	public ObservableCollection<DBCombo> DBCombos { get; }

	public DBConnectSettingsWindowContext() {
		DBCombos = new();
		FillDBCombos();
		_currentSelection = (DBCombo)_defaultDBCombo.Clone();
	}

	public DBCombo CurrentSelection {
		get => _currentSelection;
		set {
			_currentSelection = value;
			OnPropertyChanged();
		}
	}
	
	void FillDBCombos() {
		// todo тут json где-то в %appdata%
		throw new System.NotImplementedException();
	}
	
	RelayCommand? _exportCommand;
	public RelayCommand ExportCommand =>
		_exportCommand ??= new(_ => {
			
		}, null);
	
	RelayCommand? _importCommand;
	public RelayCommand ImportCommand =>
		_importCommand ??= new(_ => {
			
		}, null);
	
	RelayCommand? _displaceCommand;
	public RelayCommand DisplaceCommand =>
		_displaceCommand ??= new(_ => {
			
		}, null);
	
	RelayCommand? _applyCommand;
	public RelayCommand ApplyCommand =>
		_applyCommand ??= new(_ => {
			
		}, null);
	
	RelayCommand? _openConfigureConnectionAppCommand;
	public RelayCommand OpenConfigureConnectionAppCommand =>
		_openConfigureConnectionAppCommand ??= new(_ => {
			
		}, null);
}