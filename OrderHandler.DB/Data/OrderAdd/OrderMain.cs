using Microsoft.EntityFrameworkCore;
using OrderHandler.DB.DataModel.OrderAdd;

namespace OrderHandler.DB.Data.OrderAdd;

[Owned]
public class OrderMain : IDataModelOrderMain {
    private DateTime orderDate;
    private DateTime deliveryDate;

    string? IDataModelOrderMain.UserId => UserId;
    string IDataModelOrderMain.OrderIssue => OrderIssue;
    DateTime IDataModelOrderMain.OrderDate => OrderDate;
    DateTime IDataModelOrderMain.DeliveryDate => DeliveryDate;
    int IDataModelOrderMain.NumberOfDays => NumberOfDays;
    string IDataModelOrderMain.ProductType => ProductType;
    decimal IDataModelOrderMain.ProductCost => ProductCost;

    public string? UserId { get; set; }
    public string OrderIssue { get; set; }
    public DateTime OrderDate {
        get => orderDate;
        set {
            orderDate = value;
            SetNumberOfDays();
        }
    }
    public DateTime DeliveryDate {
        get => deliveryDate;
        set {
            deliveryDate = value;
            SetNumberOfDays();
        }
    }
    public int NumberOfDays { get; private set; }
    public string ProductType { get; set; }
    public decimal ProductCost { get; set; }

    public OrderMain() : this(null, string.Empty, DateTime.Now, DateTime.Now.AddDays(30), string.Empty, 0) { }
    public OrderMain(
        string? userId,
        string orderIssue,
        DateTime orderDate,
        DateTime deliveryDate,
        string productType,
        decimal productCost)
    {
        UserId = userId;
        OrderIssue = orderIssue;
        OrderDate = orderDate;
        DeliveryDate = deliveryDate;
        ProductType = productType;
        ProductCost = productCost;
    }

    private void SetNumberOfDays() {
        NumberOfDays = (int)(deliveryDate - orderDate).TotalDays;
        if (NumberOfDays < 0)
            NumberOfDays = 0;
    }

    public object Clone() =>
        MemberwiseClone();
}