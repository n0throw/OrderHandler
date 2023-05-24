using OrderHandler.UI.Core;
using OrderHandler.UI.Model;
using OrderHandler.UI.Core.Service.Dialog;

namespace OrderHandler.UI.Contexts;

public class AddNewOrderContext : PropertyChanger {
    ViewOrder _viewOrder;
    public ViewOrder ViewOrder {
        get => _viewOrder;
        set {
            _viewOrder = value;
            OnPropertyChanged();
        }
    }

    bool? _dialogResult;
    public bool? DialogResult {
        get => _dialogResult;
        set {
            if (value == _dialogResult)
                return;
            _dialogResult = value;
            OnPropertyChanged();
        }
    }

    readonly IDialogService _dialogService;

    public AddNewOrderContext() {
        _viewOrder = new();
        _dialogService = new DialogService();
    }


    RelayCommand? _addCommand;
    public RelayCommand AddCommand => _addCommand ??= new(_ => {
        // Тут нужен конвертер в Converters.DataType namespace из view-data в db-data
        
        // using Context dbContext = new();
        // using var transaction = dbContext.Database.BeginTransaction();
        //
        // try {
        //     dbContext.Orders.Add(_viewOrder);
        //     dbContext.SaveChanges();
        //     transaction.Commit();
        //     DialogResult = true;
        // } catch (Exception ex) {
        //     transaction.Rollback();
        //     _dialogService.ShowMessage(ex.Message);
        // }
    }, _ => ViewOrder.Validate());
}
