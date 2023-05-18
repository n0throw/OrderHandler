using Microsoft.Win32;

using System;
using System.Windows;
using System.Collections.Generic;

namespace OrderHandler.UI.Core.Service.Dialog;

public class DialogService : IDialogService {
    protected const string DefaultFilter = "Excel (.xlsx)|*.xlsx|Old Excel (.xls)|*.xls";
    protected const string InformationTitle = "Информацция";
    protected const string WarningTitle = "Предупреждение";
    protected const string ErrorTitle = "Ошибка";


    public DialogResult ShowMessage(string message, DialogLevel dialogLevel) =>
        ShowMessage(GetTitle(dialogLevel), message);

    public DialogResult ShowMessage(string title, string message) =>
        ShowMessage(title, message, DialogButton.OK);

    public DialogResult ShowMessage(string title, string message, DialogButton button) => GetDialogResult(
        MessageBox.Show(
            message,
            title,
            GetMsgButton(button)
        )
    );

    public string? OpenFileDialog(
        string title = "Сохранение Excel файла",
        string defaultFileName = "Excel файл",
        string defaultExt = ".xlsx",
        IEnumerable<string>? filters = null
    ) => ShowFileDialog(
        new OpenFileDialog() {
            FileName = defaultFileName,
            DefaultExt = defaultExt
        },
        filters
    );
    
    public string? SaveFileDialog(
        string title = "Сохранение Excel файла",
        string defaultFileName = "Excel файл",
        string defaultExt = ".xlsx",
        IEnumerable<string>? filters = null
    ) => ShowFileDialog(
        new SaveFileDialog() {
            FileName = defaultFileName,
            DefaultExt = defaultExt,
            OverwritePrompt = true
        },
        filters
    );

    string GetTitle(DialogLevel dialogLevel) => dialogLevel switch {
        DialogLevel.Information => InformationTitle,
        DialogLevel.Warning => WarningTitle,
        DialogLevel.Error => ErrorTitle,
        var _ => ErrorTitle
    };
    
    // todo сделать свои диалоговые окна
    [Obsolete("Можно использовать пока нет своих реализаций")]
    MessageBoxButton GetMsgButton(DialogButton dialogButton) => dialogButton switch {
        DialogButton.OK => MessageBoxButton.OK,
        DialogButton.OKCancel => MessageBoxButton.OKCancel,
        DialogButton.YesNo => MessageBoxButton.YesNo,
        DialogButton.YesNoCancel => MessageBoxButton.YesNoCancel,
        var _ => MessageBoxButton.OK
    };
    
    // todo сделать свои диалоговые окна
    [Obsolete("Можно использовать пока нет своих реализаций")]
    DialogResult GetDialogResult(MessageBoxResult messageBoxResult) => messageBoxResult switch {
        MessageBoxResult.None => DialogResult.None,
        MessageBoxResult.OK => DialogResult.Ok,
        MessageBoxResult.Cancel => DialogResult.Cancel,
        MessageBoxResult.Yes => DialogResult.Yes,
        MessageBoxResult.No => DialogResult.No,
        var _ => DialogResult.None
    };
    
    string? ShowFileDialog(FileDialog fileDialog, IEnumerable<string>? filters = null) {
        fileDialog.Filter = filters is null ? DefaultFilter : string.Join('|', filters);
        
        if (fileDialog.ShowDialog() == true)
            return fileDialog.FileName;
        return null;
    }
}