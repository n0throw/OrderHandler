using System;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.ViewOrderAdd.Data;

public abstract class ViewDataStatusGeneric : PropertyChanger {
    public DateTime PlannedDate { get; protected set; }
    public string? UserName { get; protected set; }
    public DateTime Date { get; protected set; }
}