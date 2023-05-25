using System.Linq;
using System.Text;
using System.Windows;
using System.Security.Cryptography;
using System.Collections.ObjectModel;

using OrderHandler.DB;
using OrderHandler.DB.Data;
using OrderHandler.DB.Data.UserAdd;

using OrderHandler.UI.Core;
using OrderHandler.UI.Model;

namespace OrderHandler.UI.Contexts; 

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