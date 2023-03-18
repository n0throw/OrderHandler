namespace OrderHandler.DB.DataModel.OrderAdd;

public interface IDataModelOrderMain : ICloneable {
    public string? UserId { get; }
    public string OrderIssue { get; }
    public DateTime OrderDate { get; }
    public DateTime DeliveryDate { get; }
    public int NumberOfDays { get; }
    public string ProductType { get; }
    public decimal ProductCost { get; }
}