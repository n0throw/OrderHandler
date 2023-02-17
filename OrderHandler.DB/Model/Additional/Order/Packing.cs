using Microsoft.EntityFrameworkCore;

namespace OrderHandler.DB.Model.Additional.Order;

[Owned]
public class Packing
{
    public StatusGeneric Status { get; set; }
    public decimal? ChipboardOrMDF { get; set; }

    public Packing() { }
    public Packing(DateTime plannedDate)
        => Status = new(plannedDate);
}