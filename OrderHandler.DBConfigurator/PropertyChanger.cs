
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OrderHandler.DBConfigurator;

public class PropertyChanger : INotifyPropertyChanged {
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string prop = "") =>
        PropertyChanged?.Invoke(this, new(prop));
}