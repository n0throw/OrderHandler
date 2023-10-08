using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OrderHandler.UI.Core; 

public class BasePropertyChanger : INotifyPropertyChanged {
	public event PropertyChangedEventHandler? PropertyChanged;

	protected void OnPropertyChanged([CallerMemberName] string prop = "") =>
		PropertyChanged?.Invoke(this, new(prop));
}