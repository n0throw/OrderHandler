using Microsoft.EntityFrameworkCore;

namespace OrderHandler.DB.Model.Additional.Order;

[Owned]
public class StatusGeneric
{
    public DateTime PlannedDate { get; set; }
    public string? UserId { get; set; } // id int
    public DateTime Date { get; set; }

    public StatusGeneric(DateTime plannedDate)
        => PlannedDate = plannedDate;
}