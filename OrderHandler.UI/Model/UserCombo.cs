using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model;

public class UserCombo : PropertyChanger {
    string _fio;

    public int Id { get; init; }
    public string FIO {
        get => _fio;
        set {
            _fio = value;
            OnPropertyChanged();
        }
    }
}
