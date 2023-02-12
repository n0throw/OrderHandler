using Microsoft.EntityFrameworkCore;

namespace OrderHandler.DB.Model.Additional.Order;

[Owned]
public class StatusGeneric
{
    public DateOnly PlannedDate { get; set; }
    public string? UserId { get; set; } // id int
    public DateOnly Date { get; set; }
}