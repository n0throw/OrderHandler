namespace OrderHandler.UI.Core.Dialog;

internal interface IDialogService
{
    string FilePath { get; }
    void ShowMessage(string message);
    bool OpenFileDialog();
    bool SaveFileDialog(string fileName = "Файл", string defaultExt = ".xlsx", string filter = "Excel (.xlsx)|*.xlsx");
}
