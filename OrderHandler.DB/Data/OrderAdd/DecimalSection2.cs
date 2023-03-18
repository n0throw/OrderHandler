using Microsoft.EntityFrameworkCore;

namespace OrderHandler.DB.Data.OrderAdd;

[Owned]
public class DecimalSection2 {
    public StatusGeneric Status { get; set; }
    public decimal Item1 { get; set; }
    public decimal Item2 { get; set; }

    public DecimalSection2() : this(DateTime.Now) { }
    public DecimalSection2(DateTime plannedDate, decimal item1 = 0, decimal item2 = 0) : this(new StatusGeneric(plannedDate), item1, item2) { }
    public DecimalSection2(StatusGeneric status, decimal item1 = 0, decimal item2 = 0) {
        Status = status;
        Item1 = item1;
        Item2 = item2;
    }
}