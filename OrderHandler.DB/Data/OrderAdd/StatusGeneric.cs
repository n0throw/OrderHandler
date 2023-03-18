using Microsoft.EntityFrameworkCore;
using OrderHandler.DB.DataModel.OrderAdd;

namespace OrderHandler.DB.Data.OrderAdd;

[Owned]
public class DocConstructor : IDataModelDocConstructor {
    DateTime IDataModelStatusGeneric.PlannedDate => PlannedDate;
    string? IDataModelStatusGeneric.UserId => UserId;
    DateTime IDataModelStatusGeneric.Date => Date;

    public DateTime PlannedDate { get; set; }
    public string? UserId { get; set; }
    public DateTime Date { get; set; }

    public DocConstructor() : this(DateTime.Now) =>
        Date = DateTime.MinValue;
    public DocConstructor(DateTime plannedDate) =>
        PlannedDate = plannedDate;

    public object Clone() =>
        MemberwiseClone();
}