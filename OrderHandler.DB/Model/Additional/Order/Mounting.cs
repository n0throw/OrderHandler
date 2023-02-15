using Microsoft.EntityFrameworkCore;

namespace OrderHandler.DB.Model.Additional.Order;

[Owned]
public class Mounting
{
    public bool IsMounting { get; set; }
    public DateTime MountingDate { get; set; }

    public Mounting(bool isMounting, DateTime mountingDate)
    {
        IsMounting = isMounting;
        MountingDate = mountingDate;
    }
}