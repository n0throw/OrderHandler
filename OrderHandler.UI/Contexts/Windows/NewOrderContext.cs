using System;

using OrderHandler.DB;
using OrderHandler.DB.Data;
using OrderHandler.DB.Data.OrderAdd;
using OrderHandler.UI.Core;
using OrderHandler.UI.Core.Service.Dialog;
using OrderHandler.UI.Model;

namespace OrderHandler.UI.Contexts.Windows;

public class NewOrderContext : MainPagePropertyChanger {
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

    public NewOrderContext() {
        _viewOrder = new();
        _dialogService = new DialogService();
    }


    RelayCommand? _addCommand;
    public RelayCommand AddCommand => _addCommand ??= new(_ => {
        //Тут нужен конвертер в Converters.DataType namespace из view-data в db-data
        
        using Context dbContext = new();
        using var transaction = dbContext.Database.BeginTransaction();
        
        try {
            OrderMain orderMain = new() {
                OrderNumber = _viewOrder.OrderMain.OrderNumber,
                OrderDate = _viewOrder.OrderMain.OrderDate,
                DeliveryDate = _viewOrder.OrderMain.DeliveryDate,
                Term = (_viewOrder.OrderMain.DeliveryDate - _viewOrder.OrderMain.OrderDate).Days,
                ProductType = _viewOrder.OrderMain.ProductType,
                OrderAmount = _viewOrder.OrderMain.OrderAmount
            };
            dbContext.OrderMains.Add(orderMain);
            
            DocConst docConst = new() {
                PlannedDate = _viewOrder.DocConst.PlannedDate,
                DateOfCompletion = _viewOrder.DocConst.DateOfCompletion
            };
            dbContext.DocConsts.Add(docConst);
            
            DocTech docTech = new() {
                PlannedDate = _viewOrder.DocTech.PlannedDate,
                DateOfCompletion = _viewOrder.DocTech.DateOfCompletion
            };
            dbContext.DocTeches.Add(docTech);
            
            Supply supply = new() {
                PlannedDate = _viewOrder.Supply.PlannedDate,
                DateOfCompletion = _viewOrder.Supply.DateOfCompletion,
                RequiredAmount = _viewOrder.Supply.RequiredAmount
            };
            dbContext.Supplies.Add(supply);
            
            SawCenter sawCenter = new() {
                PlannedDate = _viewOrder.SawCenter.PlannedDate,
                DateOfCompletion = _viewOrder.SawCenter.DateOfCompletion,
                AreaOfLCBOrMDF = _viewOrder.SawCenter.AreaOfLCBOrMDF,
                AreaOfLHDF = _viewOrder.SawCenter.AreaOfLHDF
            };
            dbContext.SawCenters.Add(sawCenter);
            
            Edge edge = new() {
                PlannedDate = _viewOrder.Edge.PlannedDate,
                DateOfCompletion = _viewOrder.Edge.DateOfCompletion,
                AreaOfLCBOrMDF = _viewOrder.Edge.AreaOfLCBOrMDF
            };
            dbContext.Edges.Add(edge);
            
            Additive additive = new() {
                PlannedDate = _viewOrder.Additive.PlannedDate,
                DateOfCompletion = _viewOrder.Additive.DateOfCompletion,
                AreaOfLCBOrMDF = _viewOrder.Additive.AreaOfLCBOrMDF
            };
            dbContext.Additives.Add(additive);
            
            Milling milling = new() {
                PlannedDate = _viewOrder.Milling.PlannedDate,
                DateOfCompletion = _viewOrder.Milling.DateOfCompletion,
                AreaOfMDF = _viewOrder.Milling.AreaOfMDF
            };
            dbContext.Millings.Add(milling);
            
            Grinding grinding = new() {
                PlannedDate = _viewOrder.Grinding.PlannedDate,
                DateOfCompletion = _viewOrder.Grinding.DateOfCompletion,
                AreaOfMDF = _viewOrder.Grinding.AreaOfMDF
            };
            dbContext.Grindings.Add(grinding);
            
            Press press = new() {
                PlannedDate = _viewOrder.Press.PlannedDate,
                DateOfCompletion = _viewOrder.Press.DateOfCompletion,
                AreaOfLCBOrMDF = _viewOrder.Press.AreaOfLCBOrMDF
            };
            dbContext.Presses.Add(press);
            
            Assembling assembling = new() {
                PlannedDate = _viewOrder.Assembling.PlannedDate,
                DateOfCompletion = _viewOrder.Assembling.DateOfCompletion,
                AreaOfLCBOrMDF = _viewOrder.Assembling.AreaOfLCBOrMDF
            };
            dbContext.Assemblings.Add(assembling);
            
            Packing packing = new() {
                PlannedDate = _viewOrder.Packing.PlannedDate,
                DateOfCompletion = _viewOrder.Packing.DateOfCompletion,
                AreaOfLCBOrMDF = _viewOrder.Packing.AreaOfLCBOrMDF
            };
            dbContext.Packings.Add(packing);
            
            Equipment equipment = new() {
                PlannedDate = _viewOrder.Equipment.PlannedDate,
                DateOfCompletion = _viewOrder.Equipment.DateOfCompletion
            };
            dbContext.Equipment.Add(equipment);
            
            Shipment shipment = new() { 
                PlannedDate = _viewOrder.Shipment.PlannedDate,
                DateOfCompletion = _viewOrder.Shipment.DateOfCompletion
            };
            dbContext.Shipments.Add(shipment);
            
            Mounting mounting = new() {
                PlannedDate = _viewOrder.Mounting.PlannedDate,
                IsNeed = _viewOrder.Mounting.IsNeed
            };
            dbContext.Mountings.Add(mounting);
            
            OrderInfo orderInfo = new() {
                OrderMain = orderMain,
                DocConst = docConst,
                DocTech = docTech,
                Supply = supply,
                SawCenter = sawCenter,
                Edge = edge,
                Additive = additive,
                Milling = milling,
                Grinding = grinding,
                Press = press,
                Assembling = assembling,
                Packing = packing,
                Equipment = equipment,
                Shipment = shipment,
                Note = _viewOrder.Note,
                Mounting = mounting
            };
            orderMain.Order = orderInfo;
            docConst.Order = orderInfo;
            docTech.Order = orderInfo;
            supply.Order = orderInfo;
            sawCenter.Order = orderInfo;
            edge.Order = orderInfo;
            additive.Order = orderInfo;
            milling.Order = orderInfo;
            grinding.Order = orderInfo;
            press.Order = orderInfo;
            assembling.Order = orderInfo;
            packing.Order = orderInfo;
            equipment.Order = orderInfo;
            shipment.Order = orderInfo;
            mounting.Order = orderInfo;
            dbContext.OrderInfos.Add(orderInfo);
            
            dbContext.SaveChanges();
            transaction.Commit();
            DialogResult = true;
        } catch (Exception ex) {
            transaction.Rollback();
            _dialogService.ShowMessage(
                ex.Message,
                DialogLevel.Error
            );
        }
    }, _ => true/*ViewOrder != null && ViewOrder.Validate()*/);
}
