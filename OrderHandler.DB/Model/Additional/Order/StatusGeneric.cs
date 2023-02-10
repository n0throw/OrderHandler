namespace OrderHandler.DB.Model.Additional.Order;

public struct StatusGeneric
{
    public DateOnly PlannedDate { get; set; }
    public int UserId { get; set; }
    public DateOnly Date { get; set; }
}