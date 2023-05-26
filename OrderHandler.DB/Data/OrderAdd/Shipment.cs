using System;

namespace OrderHandler.DB.Data.OrderAdd;

/// <summary>
/// Класс Shipment.
/// Отгрузка.
/// Модель БД.
/// </summary>
public class Shipment : OrderGeneric {
    /// <summary>
    /// Id в БД. Ключ записи
    /// </summary>
    public override long Id { get; set; }
    #region [ Basic Information ]
    /// <summary>
    /// Плановая дата
    /// </summary>
    public DateTime PlannedDate { get; set; }
    /// <summary>
    /// Дата выполнения
    /// </summary>
    public DateTime DateOfCompletion { get; set; }
    #endregion [ Basic Information ]
    #region [ Foreign Keys ]
    /// <summary>
    /// Id Пользователя.
    /// Внешний ключ
    /// </summary>
    public override long UserId { get; set; }
    /// <summary>
    /// Выполнивший пользователь.
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
    public override Order? Order { get; set; }
    #endregion [ Foreign Keys ]
}
