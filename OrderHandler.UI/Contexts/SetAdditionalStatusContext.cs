using OrderHandler.DB.Model;

using OrderHandler.UI.Core;
using OrderHandler.UI.Model;

namespace OrderHandler.UI.Contexts;

internal class SetAdditionalStatusContext : PropertyChanger
{
    private readonly Order dbOrder;
    private readonly TableSectionNames sectionName;
    private AdditionalStatus additionalStatus;
    public AdditionalStatus AdditionalStatus
    {
        get => additionalStatus;
        set
        {
            additionalStatus = value;
            OnPropertyChanged(nameof(AdditionalStatus));
        }
    }

    internal SetAdditionalStatusContext(
        Order dbOrder,
        TableSectionNames sectionName,
        AdditionalStatusVisibility statusVisibility)
    {
        this.dbOrder = dbOrder;
        this.sectionName = sectionName;
        additionalStatus = new(
            statusVisibility,
            dbOrder.Note,
            dbOrder.Mounting.Date);
    }

    private RelayCommand? acceptCommand;
    public RelayCommand AcceptCommand
        => acceptCommand ??= new RelayCommand(obj =>
        {
            switch (sectionName)
            {
                case TableSectionNames.Supply:
                    dbOrder.Supply.Cost = additionalStatus.Cost;
                    break;
                case TableSectionNames.SawCenter:
                    dbOrder.SawCenter.ChipboardOrMDF = additionalStatus.ChipboardOrMDF;
                    dbOrder.SawCenter.HDF = additionalStatus.HDF;
                    break;
                case TableSectionNames.Edge:
                    dbOrder.Edge.ChipboardOrMDF = additionalStatus.ChipboardOrMDF;
                    break;
                case TableSectionNames.Additive:
                    dbOrder.Additive.ChipboardOrMDF = additionalStatus.ChipboardOrMDF;
                    break;
                case TableSectionNames.Milling:
                    dbOrder.Milling.MDF = additionalStatus.MDF;
                    break;
                case TableSectionNames.Grinding:
                    dbOrder.Grinding.MDF = additionalStatus.MDF;
                    break;
                case TableSectionNames.Press:
                    dbOrder.Press.MDF = additionalStatus.MDF;
                    break;
                case TableSectionNames.Assembling:
                    dbOrder.Assembling.ChipboardOrMDF = additionalStatus.MDF;
                    break;
                case TableSectionNames.Packing:
                    dbOrder.Packing.ChipboardOrMDF = additionalStatus.MDF;
                    break;
                case TableSectionNames.Note:
                    dbOrder.Note = additionalStatus.Note;
                    break;
                case TableSectionNames.Mounting:
                    dbOrder.Mounting.Date = additionalStatus.Mounting;
                    break;
            }
        }, obj => AdditionalStatus.CheckAllValidation());
}