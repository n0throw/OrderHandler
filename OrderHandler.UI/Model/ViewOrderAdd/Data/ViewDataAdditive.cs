using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.ViewOrderAdd.Data;

public abstract class ViewDataAdditive : PropertyChanger {
    public ViewStatusGeneric Status { get; protected set; }
    public decimal? ChipboardOrMDF { get; protected set; }
}
