using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OrderHandler.UI.Core;

public class PropertyChanger : INotifyPropertyChanged {
    public delegate void TurnPageHandler(string? alias);
    public event TurnPageHandler? TurnPage;
    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string prop = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

    protected void GoToPage(string? alias) =>
        TurnPage?.Invoke(alias);
}