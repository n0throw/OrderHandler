using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderHandler.DB.Data.OrderAdd;

/// <summary>
/// Класс OrderMain.
/// Основная информация заказа.
/// Модель БД.
/// </summary>
public class OrderMain {
    /// <summary>
    /// Id в БД. Ключ записи
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// Номер заказа
    /// </summary>
    [Column("sOrderNumber")]
    public string OrderNumber { get; set; }
    /// <summary>
    /// Дата заказа
    /// </summary>
    [Column("dOrderDate")]
    public DateTime OrderDate { get; set; }
    /// <summary>
    /// Дата доставки
    /// </summary>
    [Column("dDeliveryDate")]
    public DateTime DeliveryDate { get; set; }
    /// <summary>
    /// Срок доставки дн.
    /// </summary>
    [Column("nTerm")]
    public long Term { get; set; }
    /// <summary>
    /// Тип изделия
    /// </summary>
    [Column("sProductType")]
    public string ProductType { get; set; }
    /// <summary>
    /// Сумма заказа
    /// </summary>
    [Column("nOrderAmount")]
    public decimal OrderAmount { get; set; }
    
    /// <summary>
    /// Id Пользователя.
    /// Внешний ключ
    /// </summary>
    public long IdUser { get; set; }
    /// <summary>
    /// Выполнивший пользователь.
    /// Внешний ключ
    /// </summary>
    [ForeignKey("IdUser")]
    public UserInfo? User { get; set; }
    
    /// <summary>
    /// Id Заказа.
    /// Внешний ключ
    /// </summary>
    public long? IdOrder { get; set; }
    /// <summary>
    /// Заказ.
    /// Внешний ключ
    /// </summary>
    [ForeignKey("IdOrder")]
    public OrderInfo? Order { get; set; }
}
