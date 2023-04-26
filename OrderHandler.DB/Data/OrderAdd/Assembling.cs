using System;

namespace OrderHandler.DB.Data.OrderAdd;

/// <summary>
/// Класс Assembling.
/// Сборка.
/// Модель БД.
/// </summary>
public class Assembling : OrderGeneric {
    /// <summary>
    /// Id в БД. Ключ записи
    /// </summary>
    public override int Id { get; set; }
    #region [ Basic Information ]
    /// <summary>
    /// Плановая дата
    /// </summary>
    public DateTime PlannedDate { get; set; }
    /// <summary>
    /// Дата выполнения
    /// </summary>
    public DateTime DateOfCompletion { get; set; }
    /// <summary>
    /// ЛДСП/МДФ м^2
    /// </summary>
    public decimal AreaOfLCBOrMDF { get; set; }
    #endregion [ Basic Information ]
    #region [ Foreign Keys ]
    /// <summary>
    /// Id Пользователя.
    /// Внешний ключ
    /// </summary>
    public override int UserId { get; set; }
    /// <summary>
    /// Выполнивший пользователь.
    /// Внешний ключ
    /// </summary>
    public override User? User { get; set; }
    /// <summary>
    /// Id Заказа.
    /// Внешний ключ
    /// </summary>
    public override int OrderId { get; set; }
    /// <summary>
    /// Заказ.
    /// Внешний ключ
    /// </summary>
    public override Order? Order { get; set; }
    #endregion [ Foreign Keys ]
}
