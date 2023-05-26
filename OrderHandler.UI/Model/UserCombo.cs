using System;

using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model;

public class UserCombo : PropertyChanger, ICloneable {
    string _fio;

    public UserCombo(long id, string? fio) {
        Id = id;
        _fio = fio ?? string.Empty;
    }
    
    public long Id { get; }
    public string FIO {
        get => _fio;
        set {
            _fio = value;
            OnPropertyChanged();
        }
    }

    public object Clone() => new UserCombo(Id, _fio);

    public override bool Equals(object? obj) {
        if (obj is UserCombo userCombo)
            return Equals(userCombo);
        
        return false;
    }

    bool Equals(UserCombo other) => 
        GetHashCode() == other.GetHashCode() && 
        _fio == other._fio;

    public override int GetHashCode() => 
        Id.GetHashCode();
}
