using System.Collections.ObjectModel;

namespace OrderHandler.DBConfigurator;

// todo переделать ReadOnly, он не работает
// todo сделать шаблоны для XAML
public class MainWindowContext : PropertyChanger {
	DBConnectionSetting? _selectedSetting;
	public ObservableCollection<DBConnectionSetting> Settings { get; set; }
	
	public MainWindowContext() {
		Settings = new();
		FillData();
	}
	
	public bool IsNameReadOnly {
		get {
			if (_selectedSetting is null)
				return true;
			
			return false;
		}
		set => OnPropertyChanged();
	}
	
	public bool IsVersionReadOnly {
		get {
			if (_selectedSetting is null)
				return true;
			
			return false;
		}
		set => OnPropertyChanged();
	}
	
	public bool IsPathReadOnly  {
		get {
			if (_selectedSetting is null)
				return true;
			
			return false;
		}
		set => OnPropertyChanged();
	}
	
	public bool IsCreateDefaultUserReadOnly  {
		get {
			if (_selectedSetting is null)
				return true;
			
			return false;
		}
		set => OnPropertyChanged();
	}
	
	public bool IsLoginReadOnly {
		get {
			if (_selectedSetting is null)
				return true;
			
			if (_selectedSetting.IsCreateDefaultUser)
				return false;
			
			return true;
		}
		set => OnPropertyChanged();
	}
	
	public bool IsPasswordReadOnly {
		get {
			if (_selectedSetting is null)
				return true;
			
			if (_selectedSetting.IsCreateDefaultUser)
				return false;
			
			return true;
		}
		set => OnPropertyChanged();
	}
	
	public DBConnectionSetting SelectedSetting {
		get => _selectedSetting ?? new();
		set {
			_selectedSetting = value;
			OnPropertyChanged();
		}
	}
	
	RelayCommand? _addCommand;
	public RelayCommand AddCommand =>
		_addCommand ??= new(_ => {
			var setting = new DBConnectionSetting();
			Settings.Insert(0, setting);
			SelectedSetting = setting;
		}, null);

	RelayCommand? _delCommand;
	public RelayCommand DelCommand =>
		_delCommand ??= new(obj => {
			if (obj is DBConnectionSetting setting) {
				Settings.Remove(setting);
			}
		}, obj => obj is DBConnectionSetting);
	
	RelayCommand? _saveCommand;
	public RelayCommand SaveCommand =>
		_saveCommand ??= new(_ => {
			//todo тут json в %appdata%
		}, null);
	
	RelayCommand? _allExportCommand;
	public RelayCommand AllExportCommand =>
		_allExportCommand ??= new(_ => {
			//todo тут экспорт имя, версии и пути в json
		}, null);
	
	RelayCommand? _onceExportCommand;
	public RelayCommand OnceExportCommand =>
		_onceExportCommand ??= new(obj => {
			if (obj is DBConnectionSetting setting) {
				//todo тут экспорт selected имя, версии и пути в json
			}
		}, obj => obj is DBConnectionSetting);
	
	RelayCommand? _createDBCommand;
	public RelayCommand CreateDBCommand =>
		_createDBCommand ??= new(obj => {
			if (obj is DBConnectionSetting setting) {
				//todo тут проверяем есть ли такая БД. Если есть нужно ли пересоздать с уточнением о удалении данных. Если нет то просто создаём
			}
		}, obj => obj is DBConnectionSetting);
	
	RelayCommand? _selectPathCommand;
	public RelayCommand SelectPathCommand =>
		_selectPathCommand ??= new(_ => {
			// todo Выбор пути сделать
		}, (_) => _selectedSetting != null);
	
	void FillData() {
		// todo тут json где-то в %appdata%
		//throw new System.NotImplementedException();
	}
}