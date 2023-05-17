﻿using Microsoft.EntityFrameworkCore.Storage;

using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

using OrderHandler.DB.Data;
using OrderHandler.UI.Contexts.CommandsImpl;
using OrderHandler.UI.Core;
using OrderHandler.UI.Model;
using OrderHandler.UI.Windows;

namespace OrderHandler.UI.Contexts;

public class TableOrderManagerContext : PropertyChanger {

    readonly ITableOrderManagerCommandsImpl _commandsImpl;
    public ObservableCollection<ViewOrder> Orders { get; private set; }

    public TableOrderManagerContext(ITableOrderManagerCommandsImpl commandsImpl) {
        Orders = new();
        _commandsImpl = commandsImpl;
        GetData();
    }

    ViewOrder? _selectedOrder;
    public ViewOrder? SelectedOrder {
        get => _selectedOrder;
        set {
            _selectedOrder = value;
            OnPropertyChanged();
        }
    }
    // ---------- Меню страницы ----------
    // ---------- Меню ----------
    RelayCommand? _updateDataCommand;
    public RelayCommand UpdateDataCommand => 
        _updateDataCommand ??= new(
            _ => Orders = new(_commandsImpl.UpdateDataCommand()), 
            null
        );

    RelayCommand? _goBackCommand;
    public RelayCommand GoBackCommand => 
        _goBackCommand ??= new(
            _ => _commandsImpl.GoBackCommand(GoToPage), 
            null
        );
    
    RelayCommand? _showStatusCommand;
    public RelayCommand ShowStatusCommand => 
        _showStatusCommand ??= new(
            _ => _commandsImpl.ShowStatusCommand(), 
            null
        );
    
    RelayCommand? _exitCommand;
    public RelayCommand ExitCommand => 
        _exitCommand ??= new(
            _ => _commandsImpl.ExitCommand(GoToPage), 
            null
        );
    
    RelayCommand? _closeAppCommand;
    public RelayCommand CloseAppCommand => 
        _closeAppCommand ??= new(
            _ => _commandsImpl.CloseAppCommand(), 
            null
        );
    
    // ---------- Утилиты ----------
    RelayCommand? _addNewOrderCommand;
    public RelayCommand AddNewOrderCommand => 
        _addNewOrderCommand ??= new(
            _ => SetNewOrders(_commandsImpl.AddNewOrderCommand()),
            null
        );
    
    RelayCommand? _massLoadingOrdersCommand;
    public RelayCommand MassLoadingOrdersCommand => 
        _massLoadingOrdersCommand ??= new(
            _ => SetNewOrders(_commandsImpl.MassLoadingOrdersCommand()), 
            null
        );
    
    RelayCommand? _uploadToExcelData;
    public RelayCommand UploadToExcelData => 
        _uploadToExcelData ??= new(
            _ => _commandsImpl.UploadToExcelData(Orders), 
            null
        );

    RelayCommand? _uploadTemplateExcel;
    public RelayCommand UploadTemplateExcel => 
        _uploadTemplateExcel ??= new(
            _ => _commandsImpl.UploadTemplateExcel(), 
            null
        );
    
    RelayCommand? _showCountOrders;
    public RelayCommand ShowCountOrders => 
        _showCountOrders ??= new(
            _ => _commandsImpl.ShowCountOrders(Orders.Count), 
            null
        );
    
    // ---------- Фильтры ----------

    RelayCommand? _setColumnFilter;
    public RelayCommand SetColumnFilter => _setColumnFilter ??= new(_ => {
        
    }, null);
    
    RelayCommand? _setRowFilter;
    public RelayCommand SetRowFilter => _setRowFilter ??= new(_ => {
        
    }, null);
    
    RelayCommand? _setQueryFilter;
    public RelayCommand SetQueryFilter => _setQueryFilter ??= new(_ => {
        
    }, null);

    // ---------- Контекстное меню ----------
    RelayCommand? _editRowOrder;
    public RelayCommand EditRowOrder => _editRowOrder ??= new(_ => {
        var newOrder = new AddNewOrder {
            DataContext = new AddNewOrderContext()
        };

        if (newOrder.ShowDialog() == true)
        {
            
        }
    }, null);
    
    RelayCommand? _delRowOrder;
    public RelayCommand DelRowOrder => _delRowOrder ??= new(_ => {
        
    }, null);
    
    RelayCommand? _changeStatusRowOrder;
    public RelayCommand ChangeStatusRowOrder => _changeStatusRowOrder ??= new(tableColumnInfoObj => {
        if (tableColumnInfoObj is not TableColumnInfo tableColumnInfo) {
            MessageBox.Show("Нет такого столбца");
            return;
        }

        if (tableColumnInfo.TableColumnName == TableColumnNames.None ||
            tableColumnInfo.TableSectionName == TableSectionNames.None)
            MessageBox.Show("Вы не выбрали строку");
        
    }, null);
    
    RelayCommand? _editNoteRowOrder;
    public RelayCommand EditNoteRowOrder => _editNoteRowOrder ??= new(_ => {
        
    }, null);
    

    // тут фильтры учитываем
    void GetData() {

    }

    void SetNewOrders(IEnumerable<ViewOrder> data) {
        if (!data.Any())
            Orders = new(data);
    }
}
