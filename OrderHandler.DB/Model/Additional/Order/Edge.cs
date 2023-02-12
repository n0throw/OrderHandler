using Microsoft.EntityFrameworkCore;

namespace OrderHandler.DB.Model.Additional.Order;

[Owned]
public class Edge
{
    public StatusGeneric Status { get; set; }
    public decimal ChipboardOrMDF { get; set; }
}