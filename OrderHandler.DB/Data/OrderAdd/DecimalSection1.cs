using Microsoft.EntityFrameworkCore;

namespace OrderHandler.DB.Data.OrderAdd;

[Owned]
public class DecimalSection1 {
    public StatusGeneric Status { get; set; }
    public decimal Item { get; set; }

    public DecimalSection1() : this(DateTime.Now) { }
    public DecimalSection1(DateTime plannedDate, decimal item = 0) : this(new StatusGeneric(plannedDate), item) { }
    public DecimalSection1(StatusGeneric status, decimal item = 0) {
        Status = status;
        Item = item;
    }
}