using OrderHandler.UI.Core;

namespace OrderHandler.UI.Contexts.Pages; 

public class MainMenuContext : PropertyChanger {

	bool _isShowFavourites;
	public bool IsShowFavourites {
		get => _isShowFavourites;
		set {
			_isShowFavourites = value;
			OnPropertyChanged();
		}
	}
	
	bool _isShowDescApp;
	public bool IsShowDescApp {
		get => _isShowDescApp;
		set {
			_isShowDescApp = value;
			OnPropertyChanged();
		}
	}
		
	bool _isShowGenericApp;
	public bool IsShowGenericApp {
		get => _isShowGenericApp;
		set {
			_isShowGenericApp = value;
			OnPropertyChanged();
		}
	}

	// ---------- Меню страницы ----------
	// ---------- Статусы ----------
	RelayCommand? _showStatusWindowCommand;
	public RelayCommand ShowStatusWindowCommand =>
		_showStatusWindowCommand ??= new(obj => {
            
		}, null);
    
	RelayCommand? _returnToLoginScreen;
	public RelayCommand ReturnToLoginScreen =>
		_returnToLoginScreen ??= new(obj => {
            
		}, null);
    
	// ---------- Настройки ----------
	RelayCommand? _showUserSettingsWindowCommand;
	public RelayCommand ShowUserSettingsWindowCommand =>
		_showUserSettingsWindowCommand ??= new(obj => {
			
		}, null);
	
	RelayCommand? _showAddSettingsWindowCommand;
	public RelayCommand ShowAddSettingsWindowCommand =>
		_showAddSettingsWindowCommand ??= new(obj => {
			
		}, null);
}