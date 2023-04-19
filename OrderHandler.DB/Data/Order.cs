using OrderHandler.DB.Data.OrderAdd;

namespace OrderHandler.DB.Data;

/// <summary>
/// Класс Order.
/// Модель заказа пользователя
/// </summary>
public class Order {
    /// <summary>
    /// Id в БД. Ключ записи
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Ссылка на основную информацию о заказе
    /// </summary>
    public OrderMain? OrderMain { get; set; }
    /// <summary>
    /// Ссылка на Документацию конструктора
    /// </summary>
    public DocConst? DocConst { get; set; }
    /// <summary>
    /// Ссылка на Документацию технолога
    /// </summary>
    public DocTech? DocTech { get; set; }
    /// <summary>
    /// Ссылка на Снабжение
    /// </summary>
    public Supply? Supply { get; set; }
    /// <summary>
    /// Ссылка на Пильный центр
    /// </summary>
    public SawCenter? SawCenter { get; set; }
    /// <summary>
    /// Ссылка на Кромку
    /// </summary>
    public Edge? Edge { get; set; }
    /// <summary>
    /// Ссылка на Присадку
    /// </summary>
    public Additive? Additive { get; set; }
    /// <summary>
    /// Ссылка на Фрезеровку
    /// </summary>
    public Milling? Milling { get; set; }
    /// <summary>
    /// Ссылка на Шлифовку
    /// </summary>
    public Grinding? Grinding { get; set; }
    /// <summary>
    /// Ссылка на Пресс
    /// </summary>
    public Press? Press { get; set; }
    /// <summary>
    /// Ссылка на Сборку
    /// </summary>
    public Assembling? Assembling { get; set; }
    /// <summary>
    /// Ссылка на Упаковку
    /// </summary>
    public Packing? Packing { get; set; }
    /// <summary>
    /// Ссылка на Комплектацию
    /// </summary>
    public Equipment? Equipment { get; set; }
    /// <summary>
    /// Ссылка на Отгрузку
    /// </summary>
    public Shipment? Shipment { get; set; }
    /// <summary>
    /// Примечание
    /// </summary>
    public string Note { get; set; }
    /// <summary>
    /// Ссылка на Монтаж
    /// </summary>
    public Mounting? Mounting { get; set; }
}
