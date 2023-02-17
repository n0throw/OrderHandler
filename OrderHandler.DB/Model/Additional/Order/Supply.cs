using Microsoft.EntityFrameworkCore;

namespace OrderHandler.DB.Model.Additional.Order;

[Owned]
public class Supply
{
    public StatusGeneric Status { get; set; }
    public decimal? Cost { get; set; }

    public Supply() { }
    public Supply(DateTime plannedDate)
        => Status = new(plannedDate);
}