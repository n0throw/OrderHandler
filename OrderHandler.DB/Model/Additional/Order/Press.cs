using Microsoft.EntityFrameworkCore;

namespace OrderHandler.DB.Model.Additional.Order;

[Owned]
public class Press
{
    public StatusGeneric Status { get; set; }
    public decimal MDF { get; set; }

    public Press(DateTime plannedDate)
        => Status = new(plannedDate);
}