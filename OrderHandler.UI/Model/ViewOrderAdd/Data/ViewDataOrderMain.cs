using System;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.ViewOrderAdd.Data;
public abstract class ViewDataOrderMain : PropertyChanger
{
    public int Number { get; protected set; }
    public string? UserName { get; protected set; }
    public string? OrderIssue { get; protected set; }
    public DateTime OrderDate { get; protected set; }
    public DateTime DeliveryDate { get; protected set; }
    public short? NumberOfDays { get; protected set; }
    public string? ProductType { get; protected set; }
    public decimal? ProductCost { get; protected set; }
}
