namespace OrderHandler.DB.Data.OrderAdd;

/// <summary>
/// Абстрактный класс OrderAddConfigureBase.
/// Общий для всех зависимых классов от Order.
/// Используется для более удобной конфигурации.
/// </summary>
public abstract class OrderGeneric {
    /// <summary>
    /// Id в БД. Ключ записи
    /// </summary>
    public abstract int Id { get; set; }
    /// <summary>
    /// Id Пользователя.
    /// Внешний ключ
    /// </summary>
    public abstract int UserId { get; set; }
    /// <summary>
    /// Выполнивший пользователь.
    /// Внешний ключ
    /// </summary>
    public abstract User? User { get; set; }
    /// <summary>
    /// Заказ.
    /// Внешний ключ
    /// </summary>
    public abstract Order? Order { get; set; }
    /// <summary>
    /// Id Заказа.
    /// Внешний ключ
    /// </summary>
    public abstract int OrderId { get; set; }
}