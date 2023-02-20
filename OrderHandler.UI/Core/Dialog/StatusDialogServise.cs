using OrderHandler.DB.Model;
using OrderHandler.DB.Model.Additional.Order;
using OrderHandler.UI.Model;
using OrderHandler.UI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OrderHandler.UI.Core.Dialog;

internal class StatusDialogServise
{
    protected readonly Order dbOrder;
    protected readonly TableSectionNames sectionName;
    private readonly IDialogService dialogService;
    private static readonly Dictionary<TableSectionNames, AdditionalStatusVisibility> visibilityStatuses = new()
    {
        {
            TableSectionNames.Supply,
            new(cost: Visibility.Visible)
        },
        {
            TableSectionNames.SawCenter,
            new(chipboardOrMDF: Visibility.Visible,
                hdf: Visibility.Visible)
        },
        {
            TableSectionNames.Edge,
            new(chipboardOrMDF: Visibility.Visible)
        },
        {
            TableSectionNames.Additive,
            new(chipboardOrMDF: Visibility.Visible)
        },
        {
            TableSectionNames.Milling,
            new(mdf: Visibility.Visible)
        },
        {
            TableSectionNames.Grinding,
            new(mdf: Visibility.Visible)
        },
        {
            TableSectionNames.Press,
            new(mdf: Visibility.Visible)
        },
        {
            TableSectionNames.Assembling,
            new(chipboardOrMDF: Visibility.Visible)
        },
        {
            TableSectionNames.Packing,
            new(chipboardOrMDF: Visibility.Visible)
        },
        {
            TableSectionNames.Mounting,
            new(mounting: Visibility.Visible)
        },
        {
            TableSectionNames.Note,
            new(note: Visibility.Visible)
        },
    };

    internal StatusDialogServise(
        Order dbOrder,
        TableSectionNames sectionName)
    {
        this.dbOrder = dbOrder;
        this.sectionName = sectionName;
        dialogService = new DefaultDialogService();
    }
    
    internal void DelStatus()
    {
        switch (sectionName)
        {
            case TableSectionNames.DocConstructor:
                if (CheckDateNow(dbOrder.DocumentationConstructor))
                    DelSatusGeneric(dbOrder.DocumentationConstructor);
                break;
            case TableSectionNames.DocTechnologist:
                if (CheckDateNow(dbOrder.DocumentationTechnologist))
                    DelSatusGeneric(dbOrder.DocumentationTechnologist);
                break;
            case TableSectionNames.Supply:
                if (CheckDateNow(dbOrder.Supply.Status))
                {
                    DelSatusGeneric(dbOrder.Supply.Status);
                    dbOrder.Supply.Cost = null;
                }
                break;
            case TableSectionNames.SawCenter:
                if (CheckDateNow(dbOrder.SawCenter.Status))
                {
                    DelSatusGeneric(dbOrder.SawCenter.Status);
                    dbOrder.SawCenter.ChipboardOrMDF = null;
                    dbOrder.SawCenter.HDF = null;
                }
                break;
            case TableSectionNames.Edge:
                if (CheckDateNow(dbOrder.Edge.Status))
                {
                    DelSatusGeneric(dbOrder.Edge.Status);
                    dbOrder.Edge.ChipboardOrMDF = null;
                }
                break;
            case TableSectionNames.Additive:
                if (CheckDateNow(dbOrder.Additive.Status))
                {
                    DelSatusGeneric(dbOrder.Additive.Status);
                    dbOrder.Additive.ChipboardOrMDF = null;
                }
                break;
            case TableSectionNames.Milling:
                if (CheckDateNow(dbOrder.Milling.Status))
                {
                    DelSatusGeneric(dbOrder.Milling.Status);
                    dbOrder.Milling.MDF = null;
                }
                break;
            case TableSectionNames.Grinding:
                if (CheckDateNow(dbOrder.Grinding.Status))
                {
                    DelSatusGeneric(dbOrder.Grinding.Status);
                    dbOrder.Grinding.MDF = null;
                }
                break;
            case TableSectionNames.Press:
                if (CheckDateNow(dbOrder.Press.Status))
                {
                    DelSatusGeneric(dbOrder.Press.Status);
                    dbOrder.Press.MDF = null;
                }
                break;
            case TableSectionNames.Assembling:
                if (CheckDateNow(dbOrder.Assembling.Status))
                {
                    DelSatusGeneric(dbOrder.Assembling.Status);
                    dbOrder.Assembling.ChipboardOrMDF = null;
                }
                break;
            case TableSectionNames.Packing:
                if (CheckDateNow(dbOrder.Packing.Status))
                {
                    DelSatusGeneric(dbOrder.Packing.Status);
                    dbOrder.Packing.ChipboardOrMDF = null;
                }
                break;
            case TableSectionNames.Equipment:
                if (!CheckDateNow(dbOrder.Equipment))
                    return;
                DelSatusGeneric(dbOrder.Equipment);
                break;
            case TableSectionNames.Shipment:
                if (!CheckDateNow(dbOrder.Shipment))
                    return;
                DelSatusGeneric(dbOrder.Shipment);
                break;
            case TableSectionNames.Note:
                dbOrder.Note = null;
                break;
            case TableSectionNames.Mounting:
                dbOrder.Mounting.IsMounting = false;
                dbOrder.Mounting.Date = DateTime.MinValue;
                break;
        }
    }

    internal void SetStatus()
    {
        switch (sectionName)
        {
            case TableSectionNames.DocConstructor:
                if (!CheckChangedStatus(dbOrder.DocumentationConstructor))
                    return;
                SetSatusGeneric(dbOrder.DocumentationConstructor);
                break;
            case TableSectionNames.DocTechnologist:
                if (!CheckChangedStatus(dbOrder.DocumentationTechnologist))
                    return;
                SetSatusGeneric(dbOrder.DocumentationTechnologist);
                break;
            case TableSectionNames.Supply:
                if (!CheckChangedStatus(dbOrder.Supply.Status))
                    return;
                if (SetAddativeCell() == true)
                    SetSatusGeneric(dbOrder.Supply.Status);
                break;
            case TableSectionNames.SawCenter:
                if (!CheckChangedStatus(dbOrder.SawCenter.Status))
                    return;
                if (SetAddativeCell() == true)
                    SetSatusGeneric(dbOrder.SawCenter.Status);
                break;
            case TableSectionNames.Edge:
                if (!CheckChangedStatus(dbOrder.Edge.Status))
                    return;
                if (SetAddativeCell() == true)
                    SetSatusGeneric(dbOrder.Edge.Status);
                break;
            case TableSectionNames.Additive:
                if (!CheckChangedStatus(dbOrder.Additive.Status))
                    return;
                if (SetAddativeCell() == true)
                    SetSatusGeneric(dbOrder.Additive.Status);
                break;
            case TableSectionNames.Milling:
                if (!CheckChangedStatus(dbOrder.Milling.Status))
                    return;
                if (SetAddativeCell() == true)
                    SetSatusGeneric(dbOrder.Milling.Status);
                break;
            case TableSectionNames.Grinding:
                if (!CheckChangedStatus(dbOrder.Grinding.Status))
                    return;
                if (SetAddativeCell() == true)
                    SetSatusGeneric(dbOrder.Grinding.Status);
                break;
            case TableSectionNames.Press:
                if (!CheckChangedStatus(dbOrder.Press.Status))
                    return;
                if (SetAddativeCell() == true)
                    SetSatusGeneric(dbOrder.Press.Status);
                break;
            case TableSectionNames.Assembling:
                if (!CheckChangedStatus(dbOrder.Assembling.Status))
                    return;
                if (SetAddativeCell() == true)
                    SetSatusGeneric(dbOrder.Assembling.Status);
                break;
            case TableSectionNames.Packing:
                if (!CheckChangedStatus(dbOrder.Packing.Status))
                    return;
                if (SetAddativeCell() == true)
                    SetSatusGeneric(dbOrder.Packing.Status);
                break;
            case TableSectionNames.Equipment:
                if (!CheckChangedStatus(dbOrder.Equipment))
                    return;
                SetSatusGeneric(dbOrder.Equipment);
                break;
            case TableSectionNames.Shipment:
                if (!CheckChangedStatus(dbOrder.Shipment))
                    return;
                SetSatusGeneric(dbOrder.Shipment);
                break;
            case TableSectionNames.Note:
                SetAddativeCell();
                break;
            case TableSectionNames.Mounting:
                if (SetAddativeCell() == true)
                    dbOrder.Mounting.IsMounting = true;
                break;
        }
    }

    private bool? SetAddativeCell()
    {
        SetAdditionalStatus setAdditional = new(
            dbOrder,
            sectionName,
            visibilityStatuses[sectionName]);

        return setAdditional.ShowDialog();
    }

    protected bool CheckChangedStatus(StatusGeneric status) 
    {
        if (status.UserId is not null
            && status.Date != DateTime.MinValue)
        {
            dialogService.ShowMessage($"Статус уже установлен Пользователем: {status.UserId}");
            return false;
        }

        return true;
    }

    protected bool CheckDateNow(StatusGeneric status)
        => status.Date.Date == DateTime.Now.Date;

    protected void SetSatusGeneric(StatusGeneric status)
    {
        status.Date = DateTime.Now;
        status.UserId = "Анонимов Аноним Анонимович";
    }

    protected void DelSatusGeneric(StatusGeneric status)
    {
        status.Date = DateTime.MinValue;
        status.UserId = null;
    }
}
