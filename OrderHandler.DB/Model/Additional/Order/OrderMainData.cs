using Microsoft.EntityFrameworkCore;

namespace OrderHandler.DB.Model.Additional.Order;

[Owned]
public class OrderMainData
{
    public string UserDataId { get; set; } // int id в бд с пользователями
    public string OrderIssue { get; set; }
    public DateOnly OrderDate { get; set; }
    public DateOnly DeliveryDate { get; set; }
    public short NumberOfDays { get; set; }
    public string ProductType { get; set; }
    public decimal ProductCost { get; set; }
}