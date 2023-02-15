using Microsoft.EntityFrameworkCore;

namespace OrderHandler.DB.Model.Additional.Order;

[Owned]
public class SawCenter
{
    public StatusGeneric Status { get; set; }
    public decimal ChipboardOrMDF { get; set; }
    public decimal HDF { get; set; }

    public SawCenter(DateTime plannedDate)
        => Status = new(plannedDate);
}