using System;

namespace OrderHandler.DBConfigurator; 

public class DBConnectionSetting : PropertyChanger {
	string _name = string.Empty;
	string _version = string.Empty;
	string _path = string.Empty;
	bool _isCreateDefaultUser;
	string _login  = string.Empty;
	string _password  = string.Empty;

	public DBConnectionSetting() {
		
	}

	public string Name {
		get => _name;
		set {
			_name = value;
			OnPropertyChanged();
		}
	}
	
	public string Version {
		get => _version;
		set {
			_version = value;
			OnPropertyChanged();
		}
	}
	
	public string Path {
		get => _path;
		set {
			_path = value;
			OnPropertyChanged();
		}
	}
	
	public bool IsCreateDefaultUser {
		get => _isCreateDefaultUser;
		set {
			_isCreateDefaultUser = value;
			OnPropertyChanged();
		}
	}
	
	public string Login {
		get => _login;
		set {
			_login = value;
			OnPropertyChanged();
		}
	}
	
	public string Password {
		get => _password;
		set {
			_password = value;
			OnPropertyChanged();
		}
	}
}