namespace OrderHandler.DB.DataModel.OrderAdd;

public interface IDataModelStatusGeneric : ICloneable {
    public DateTime PlannedDate{ get;}
    public string? UserId { get; }
    public DateTime Date { get; }
}