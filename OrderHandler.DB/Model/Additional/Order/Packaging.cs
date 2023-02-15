using Microsoft.EntityFrameworkCore;

namespace OrderHandler.DB.Model.Additional.Order;

[Owned]
public class Packaging
{
    public StatusGeneric Status { get; set; }
    public decimal ChipboardOrMDF { get; set; }

    public Packaging(DateTime plannedDate)
        => Status = new(plannedDate);
}