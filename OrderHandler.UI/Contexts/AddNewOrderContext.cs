using Microsoft.EntityFrameworkCore.Storage;
using OrderHandler.DB;
using OrderHandler.UI.Core;
using OrderHandler.UI.Core.Dialog;
using OrderHandler.UI.Model;

using System;

namespace OrderHandler.UI.Contexts;

public class AddNewOrderContext : PropertyChanger {
    private ViewOrder viewOrder;
    public ViewOrder ViewOrder {
        get => viewOrder;
        set {
            viewOrder = value;
            OnPropertyChanged(nameof(ViewOrder));
        }
    }

    private bool? dialogResult;
    public bool? DialogResult {
        get => dialogResult;
        set {
            if (value != dialogResult) {
                dialogResult = value;
                OnPropertyChanged(nameof(DialogResult));
            }
        }
    }

    private readonly IDialogService dialogService;

    public AddNewOrderContext() {
        viewOrder = new();
        dialogService = new DefaultDialogService();
    }


    private RelayCommand? addCommand;
    public RelayCommand AddCommand =>
        addCommand ??= new RelayCommand(obj => {
            using OrderContext db = new();
            using IDbContextTransaction transaction = db.Database.BeginTransaction();

            try {
                db.Orders.Add(viewOrder);
                db.SaveChanges();
                transaction.Commit();
                DialogResult = true;
            } catch (Exception ex) {
                transaction.Rollback();
                dialogService.ShowMessage(ex.Message);
            }
        }, obj => ViewOrder.Validate());
}
