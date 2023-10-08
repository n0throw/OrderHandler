using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using OrderHandler.DB.Data.UserAdd;
using OrderHandler.DB.Data.OrderAdd;

namespace OrderHandler.DB.Data;

/// <summary>
/// Класс User.
/// Модель пользователя
/// </summary>
public class UserInfo {
	/// <summary>
    /// Id в БД. Ключ записи
    /// </summary>
    public long Id { get; set; }

	/// <summary>
	/// Логин пользователя
	/// </summary>
	[Column("sLogin")]
	public string Login { get; set; } = string.Empty;

	/// <summary>
	/// Хэш пароля
	/// </summary>
	[Column("sPasswordHash")]
	public string PasswordHash { get; set; } = string.Empty;
    
    /// <summary>
    /// Id пользователя, который создал данную Роль
    /// </summary>
    public long? IdCreateUser { get; set; }
	
	/// <summary>
	/// Пользователь, который создал данную Роль
	/// </summary>
	[ForeignKey("IdCreateUser")]
	public UserInfo? CreateUser { get; set; }
	
    /// <summary>
    /// Дата + Время создания данной Роли
    /// </summary>
    [Column("dDateOfCreation")]
    public DateTime? DateOfCreation { get; set; }
	
    /// <summary>
    /// Id последнего отредактирующего данную Роль пользователя
    /// </summary>
    public long? IdLastEditUser { get; set; }

	/// <summary>
    /// Пользователь, последний отредактировавший данную Роль
    /// </summary>
    public UserInfo? LastEditUser { get; set; }
	
	/// <summary>
	/// Дата + Время, когда данная Роль была в последний раз отредактирована
	/// </summary>
	[Column("dDateOfEditing")]
	public DateTime? DateOfEditing { get; set; }
	
	/// <summary>
	/// Id Роли пользователя.
	/// Внешний ключ
	/// </summary>
	public long? IdRole { get; set; }
    
	/// <summary>
	/// Роль пользователя.
	/// </summary>
	[ForeignKey("IdRole")]
	public RoleInfo? Role { get; set; }

	/// <summary>
	/// Id Личного имени пользователя во всех падежах. 
	/// </summary>
	public long? IdCaseName { get; set; }
	
	/// <summary>
	/// Личное имя пользователя во всех падежах.
	/// </summary>
	[ForeignKey("IdCaseName")]
	public CaseName? CaseName { get; set; }

	/// <summary>
	/// Отредактированные пользователи
	/// </summary>
	public ICollection<UserInfo> EditedUsers { get; set; } = new List<UserInfo>();

	/// <summary>
	/// Отредактированные Роли
	/// </summary>
	public ICollection<RoleInfo> EditedRoles { get; set; } = new List<RoleInfo>();

	/// <summary>
	/// Созданные пользователи
	/// </summary>
	public ICollection<UserInfo> CreatedUsers { get; set; } = new List<UserInfo>();

	/// <summary>
	/// Созданные Роли
	/// </summary>
	public ICollection<RoleInfo> CreatedRoles { get; set; } = new List<RoleInfo>();

	/// <summary>
	/// Список Основной информации
	/// </summary>
	public ICollection<OrderMain> OrderMains { get; set; } = new List<OrderMain>();

	/// <summary>
	/// Список Документации конструктора
	/// </summary>
	public ICollection<DocConst> DocConsts { get; set; } = new List<DocConst>();

	/// <summary>
	/// Список Документации технолога
	/// </summary>
	public ICollection<DocTech> DocTeches { get; set; } = new List<DocTech>();

	/// <summary>
	/// Список Снабжения
	/// </summary>
	public ICollection<Supply> Supplies { get; set; } = new List<Supply>();

	/// <summary>
	/// Список Пильного центра
	/// </summary>
	public ICollection<SawCenter> SawCenters { get; set; } = new List<SawCenter>();

	/// <summary>
	/// Список Кромки
	/// </summary>
	public ICollection<Edge> Edges { get; set; } = new List<Edge>();

	/// <summary>
	/// Список Присадки
	/// </summary>
	public ICollection<Additive> Additives { get; set; } = new List<Additive>();

	/// <summary>
	/// Список Фрезеровки
	/// </summary>
	public ICollection<Milling> Millings { get; set; } = new List<Milling>();

	/// <summary>
	/// Список Шлифовки
	/// </summary>
	public ICollection<Grinding> Grindings { get; set; } = new List<Grinding>();

	/// <summary>
	/// Список Пресса
	/// </summary>
	public ICollection<Press> Presses { get; set; } = new List<Press>();

	/// <summary>
	/// Список Сборки
	/// </summary>
	public ICollection<Assembling> Assemblings { get; set; } = new List<Assembling>();

	/// <summary>
	/// Список Упаковки
	/// </summary>
	public ICollection<Packing> Packings { get; set; } = new List<Packing>();

	/// <summary>
	/// Список Комплектации
	/// </summary>
	public ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();

	/// <summary>
	/// Список Отгрузки
	/// </summary>
	public ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

	/// <summary>
	/// Список Монтажа
	/// </summary>
	public ICollection<Mounting> Mountings { get; set; } = new List<Mounting>();
}
