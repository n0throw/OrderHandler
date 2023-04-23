using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model;

public class UserCombo : PropertyChanger {
    private string fio;

    public int Id { get; init; }
    public string FIO {
        get => fio;
        set => OnPropertyChanged(nameof(FIO));
    }

}
