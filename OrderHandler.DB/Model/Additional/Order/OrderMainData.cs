namespace OrderHandler.DB.Model.Additional.Order;

public struct OrderMainData
{
    public int UserDataId { get; set; }
    public string OrderIssue { get; set; }
    public DateOnly OrderDate { get; set; }
    public DateOnly DeliveryDate { get; set; }
    public short NumberOfDays { get; set; }
    public string ProductType { get; set; }
    public decimal ProductCost { get; set; }
}