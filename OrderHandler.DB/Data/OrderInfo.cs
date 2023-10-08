using System.ComponentModel.DataAnnotations.Schema;

using OrderHandler.DB.Data.OrderAdd;

namespace OrderHandler.DB.Data;

/// <summary>
/// Класс Order.
/// Модель заказа пользователя
/// </summary>
public class OrderInfo {
    /// <summary>
    /// Id в БД. Ключ записи
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// Ссылка на основную информацию о заказе
    /// </summary>
    public OrderMain OrderMain { get; set; } = new();
    /// <summary>
    /// Ссылка на Документацию конструктора
    /// </summary>
    public DocConst DocConst { get; set; } = new();
    /// <summary>
    /// Ссылка на Документацию технолога
    /// </summary>
    public DocTech DocTech { get; set; } = new();
    /// <summary>
    /// Ссылка на Снабжение
    /// </summary>
    public Supply Supply { get; set; } = new();
    /// <summary>
    /// Ссылка на Пильный центр
    /// </summary>
    public SawCenter SawCenter { get; set; } = new();
    /// <summary>
    /// Ссылка на Кромку
    /// </summary>
    public Edge Edge { get; set; } = new();
    /// <summary>
    /// Ссылка на Присадку
    /// </summary>
    public Additive Additive { get; set; } = new();
    /// <summary>
    /// Ссылка на Фрезеровку
    /// </summary>
    public Milling Milling { get; set; } = new();
    /// <summary>
    /// Ссылка на Шлифовку
    /// </summary>
    public Grinding Grinding { get; set; } = new();
    /// <summary>
    /// Ссылка на Пресс
    /// </summary>
    public Press Press { get; set; } = new();
    /// <summary>
    /// Ссылка на Сборку
    /// </summary>
    public Assembling Assembling { get; set; } = new();
    /// <summary>
    /// Ссылка на Упаковку
    /// </summary>
    public Packing Packing { get; set; } = new();
    /// <summary>
    /// Ссылка на Комплектацию
    /// </summary>
    public Equipment Equipment { get; set; } = new();
    /// <summary>
    /// Ссылка на Отгрузку
    /// </summary>
    public Shipment Shipment { get; set; } = new();
    /// <summary>
    /// Примечание
    /// </summary>
    [Column("sNote")]
    public string Note { get; set; } = string.Empty;

    /// <summary>
    /// Ссылка на Монтаж
    /// </summary>
    public Mounting Mounting { get; set; } = new();
}
