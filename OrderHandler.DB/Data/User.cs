using System.Collections.Generic;
using OrderHandler.DB.Data.OrderAdd;
using OrderHandler.DB.Data.UserAdd;

namespace OrderHandler.DB.Data;

/// <summary>
/// Класс User.
/// Модель пользователя
/// </summary>
public class User
{
    /// <summary>
    /// Id в БД. Ключ записи
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Логин пользователя
    /// </summary>
    public string Login { get; set; }
    /// <summary>
    /// Хэш Пароля
    /// </summary>
    public string PasswordHash { get; set; }

    /// <summary>
    /// ФИО пользователя во всех склонениях
    /// </summary>
    public CaseName? Profile { get; set; }

    /// <summary>
    /// Список Основной информации
    /// </summary>
    public List<OrderMain> OrderMain { get; set; } = new();
    /// <summary>
    /// Список Документации конструктора
    /// </summary>
    public List<DocConst> DocConst { get; set; } = new();
    /// <summary>
    /// Список Документации технолога
    /// </summary>
    public List<DocTech> DocTech { get; set; } = new();
    /// <summary>
    /// Список Снабжения
    /// </summary>
    public List<Supply> Supply { get; set; } = new();
    /// <summary>
    /// Список Пильного центра
    /// </summary>
    public List<SawCenter> SawCenter { get; set; } = new();
    /// <summary>
    /// Список Кромки
    /// </summary>
    public List<Edge> Edge { get; set; } = new();
    /// <summary>
    /// Список Присадки
    /// </summary>
    public List<Additive> Additive { get; set; } = new();
    /// <summary>
    /// Список Фрезеровки
    /// </summary>
    public List<Milling> Milling { get; set; } = new();
    /// <summary>
    /// Список Шлифовки
    /// </summary>
    public List<Grinding> Grinding { get; set; } = new();
    /// <summary>
    /// Список Пресса
    /// </summary>
    public List<Press> Press { get; set; } = new();
    /// <summary>
    /// Список Сборки
    /// </summary>
    public List<Assembling> Assembling { get; set; } = new();
    /// <summary>
    /// Список Упаковки
    /// </summary>
    public List<Packing> Packing { get; set; } = new();
    /// <summary>
    /// Список Комплектации
    /// </summary>
    public List<Equipment> Equipment { get; set; } = new();
    /// <summary>
    /// Список Отгрузки
    /// </summary>
    public List<Shipment> Shipment { get; set; } = new();
    /// <summary>
    /// Список Монтажаs
    /// </summary>
    public List<Mounting> Mounting { get; set; } = new();
}
