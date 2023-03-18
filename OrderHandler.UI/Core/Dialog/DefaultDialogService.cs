using Microsoft.Win32;
using System;
using System.Windows;

namespace OrderHandler.UI.Core.Dialog;

public class DefaultDialogService : IDialogService {
    private string? filePath;

    public string FilePath => filePath ?? AppDomain.CurrentDomain.BaseDirectory;

    public bool OpenFileDialog() {
        OpenFileDialog openFileDialog = new();
        bool output = openFileDialog.ShowDialog() == true;

        if (output)
            filePath = openFileDialog.FileName;

        return output;
    }

    public bool SaveFileDialog(string fileName = "Файл", string defaultExt = ".xlsx", string filter = "Excel (.xlsx)|*.xlsx") {
        SaveFileDialog saveFileDialog = new() {
            FileName = fileName,
            DefaultExt = defaultExt,
            Filter = filter
        };

        bool output = saveFileDialog.ShowDialog() == true;

        if (output)
            filePath = saveFileDialog.FileName;
        return output;
    }

    public void ShowMessage(string message) =>
        MessageBox.Show(message, "Информация");
}