using System.Collections.Generic;

namespace OrderHandler.UI.Core.Service.Dialog;

public interface IDialogService {
    DialogResult ShowMessage(string message, DialogLevel dialogLevel);
    DialogResult ShowMessage(string title, string message);
    DialogResult ShowMessage(string title, string message, DialogButton button);
    // todo после создания своих диалоговых окон, они должны поддерживать иконки
    //DialogResult ShowMessage(string title, string message, DialogButton button, DialogLevel dialogLevel, Image image);
    
    // todo должен возвращать класс с инфой о файле: путь, extension и мейби ещё чего-то
    string? OpenFileDialog(
        string title,
        string defaultFileName,
        string defaultExt,
        IEnumerable<string>? filters
    );
    
    // todo должен возвращать класс с инфой о файле: путь, extension и мейби ещё чего-то
    string? SaveFileDialog(
        string title,
        string defaultFileName,
        string defaultExt,
        IEnumerable<string>? filters
    );
}
