using OrderHandler.DB.Model;

using OrderHandler.UI.Contexts;
using OrderHandler.UI.Core;
using OrderHandler.UI.Model;
using System.Windows;

namespace OrderHandler.UI.Windows;

public partial class SetAdditionalStatus : Window
{
    public SetAdditionalStatus(Order dbOrder, TableSectionNames sectionName, AdditionalStatusVisibility statusVisibility)
    {
        InitializeComponent();
        DataContext = new SetAdditionalStatusContext(
            dbOrder,
            sectionName,
            statusVisibility);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
        => DialogResult = true;
}
