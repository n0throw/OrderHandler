using System;

namespace OrderHandler.DB.Data.OrderAdd;

/// <summary>
/// Класс OrderMain.
/// Основная информация заказа.
/// Модель БД.
/// </summary>
public class OrderMain : OrderGeneric {
    /// <summary>
    /// Id в БД. Ключ записи
    /// </summary>
    public override long Id { get; set; }
    #region [ Basic Information ]
    /// <summary>
    /// Номер заказа
    /// </summary>
    public string OrderNumber { get; set; }
    /// <summary>
    /// Дата заказа
    /// </summary>
    public DateTime OrderDate { get; set; }
    /// <summary>
    /// Дата доставки
    /// </summary>
    public DateTime DeliveryDate { get; set; }
    /// <summary>
    /// Срок доставки дн.
    /// </summary>
    public int Term { get; set; }
    /// <summary>
    /// Тип изделия
    /// </summary>
    public string ProductType { get; set; }
    /// <summary>
    /// Сумма заказа
    /// </summary>
    public decimal OrderAmount { get; set; }
    #endregion [ Basic Information ]
    #region [ Foreign Keys ]
    /// <summary>
    /// Id Менеджера заказа.
    /// Внешний ключ
    /// </summary>
    public override long UserId { get; set; }
    /// <summary>
    /// Менеджер заказа.
    /// Внешний ключ
    /// </summary>
    public override User? User { get; set; }
    /// <summary>
    /// Id Заказа.
    /// Внешний ключ
    /// </summary>
    public override long OrderId { get; set; }
    /// <summary>
    /// Заказ.
    /// Внешний ключ
    /// </summary>
    public override Order? Order{ get; set; }
    #endregion [ Foreign Keys ]
}
