using Microsoft.EntityFrameworkCore;

namespace OrderHandler.DB.Model.Additional.Order;

[Owned]
public class Grinding
{
    public StatusGeneric Status { get; set; }
    public decimal MDF { get; set; }

    public Grinding(DateTime plannedDate)
        => Status = new(plannedDate);
}