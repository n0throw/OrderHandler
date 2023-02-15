using Microsoft.EntityFrameworkCore;

namespace OrderHandler.DB.Model.Additional.Order;

[Owned]
public class OrderMainData
{
    public string UserDataId { get; set; } // int id в бд с пользователями
    public string OrderIssue { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public short NumberOfDays { get; set; }
    public string ProductType { get; set; }
    public decimal ProductCost { get; set; }

    public OrderMainData(string userDataId, string orderIssue, DateTime orderDate, DateTime deliveryDate, short numberOfDays, string productType, decimal productCost)
    {
        UserDataId = userDataId;
        OrderIssue = orderIssue;
        OrderDate = orderDate;
        DeliveryDate = deliveryDate;
        NumberOfDays = numberOfDays;
        ProductType = productType;
        ProductCost = productCost;
    }
}