using Microsoft.EntityFrameworkCore;
using OrderHandler.DB.DataModel.OrderAdd;

namespace OrderHandler.DB.Data.OrderAdd;

[Owned]
public class Mounting : IDataModelMounting {
    bool IDataModelMounting.IsMounting => IsMounting;
    DateTime IDataModelMounting.Date => Date;

    public bool IsMounting { get; set; }
    public DateTime Date { get; set; }

    public Mounting() : this(false, DateTime.MinValue) { }
    public Mounting(bool isMounting, DateTime date)
    {
        IsMounting = isMounting;

        if (isMounting)
            Date = date;
    }

    public object Clone() =>
        MemberwiseClone();
}