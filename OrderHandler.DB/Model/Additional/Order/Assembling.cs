using Microsoft.EntityFrameworkCore;

namespace OrderHandler.DB.Model.Additional.Order;

[Owned]
public class Assembling
{
    public StatusGeneric Status { get; set; }
    public decimal? ChipboardOrMDF { get; set; }

    public Assembling() { }
    public Assembling(DateTime plannedDate)
        => Status = new(plannedDate);
}