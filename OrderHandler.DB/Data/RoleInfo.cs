using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using OrderHandler.DB.Data.RoleAdd;

namespace OrderHandler.DB.Data; 

public class RoleInfo {
	/// <summary>
	/// Id в БД. Ключ записи
	/// </summary>
	public long Id { get; set; }

	/// <summary>
	/// Наименование роли
	/// </summary>
	[Column("sName")]
	public string Name { get; set; } = string.Empty;
	
	/// <summary>
	/// Id пользователя, который создал данную Роль
	/// </summary>
	public long? IdCreateUser { get; set; }
	
	/// <summary>
	/// Дата + Время создания данной Роли
	/// </summary>
	[Column("dDateOfCreation")]
	public DateTime? DateOfCreation { get; set; }
	
	/// <summary>
	/// Пользователь, который создал данную Роль
	/// </summary>
	[ForeignKey("IdCreateUser")]
	public UserInfo? CreateUser { get; set; }
	
	/// <summary>
	/// Id последнего отредактирующего данную Роль пользователя
	/// </summary>
	public long? IdLastEditUser { get; set; }
	
	/// <summary>
	/// Дата + Время, когда данная Роль была в последний раз отредактирована
	/// </summary>
	[Column("dDateOfEditing")]
	public DateTime? DateOfEditing { get; set; }
	
	/// <summary>
	/// Пользователь, последний отредактировавший данную Роль
	/// </summary>
	public UserInfo? LastEditUser { get; set; }

	/// <summary>
	/// Разрешения, которые есть у данной Роли
	/// </summary>
	public ICollection<RoleAuthority> RoleAuthorities { get; set; } = new List<RoleAuthority>();

	/// <summary>
	/// Список Пользователей, у которых есть данная роль
	/// </summary>
	public ICollection<UserInfo> Users { get; set; } = new List<UserInfo>();
}