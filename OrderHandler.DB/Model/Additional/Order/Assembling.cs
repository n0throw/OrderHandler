using Microsoft.EntityFrameworkCore;
using OrderHandler.DB.Model.Additional.Order;

namespace OrderHandler.DB.Model.Additional.Order;

[Owned]
public class Assembling
{
    public StatusGeneric Status { get; set; }
    public decimal ChipboardOrMDF { get; set; }
}