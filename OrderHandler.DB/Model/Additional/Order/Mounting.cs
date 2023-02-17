using Microsoft.EntityFrameworkCore;

namespace OrderHandler.DB.Model.Additional.Order;

[Owned]
public class Mounting
{
    public bool IsMounting { get; set; }
    public DateTime Date { get; set; }

    public Mounting() { }
    public Mounting(bool isMounting, DateTime date)
    {
        IsMounting = isMounting;

        if (isMounting)
            Date = date;
    }
}