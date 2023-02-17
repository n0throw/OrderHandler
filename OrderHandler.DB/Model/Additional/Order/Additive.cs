using Microsoft.EntityFrameworkCore;

namespace OrderHandler.DB.Model.Additional.Order;

[Owned]
public class Additive
{
    public StatusGeneric Status { get; set; }
    public decimal? ChipboardOrMDF { get; set; }

    public Additive() { }
    public Additive(DateTime plannedDate)
        => Status = new(plannedDate);
}