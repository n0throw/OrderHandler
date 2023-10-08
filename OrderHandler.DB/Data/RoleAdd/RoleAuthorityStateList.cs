using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderHandler.DB.Data.RoleAdd; 

public class RoleAuthorityStateList {
	public long Id { get; set; }

	[Column("sSystemName")]
	public string SystemName { get; set; } = null!;

	[Column("sName")]
	public string Name { get; set; } = null!;

	public ICollection<RoleAuthorityAvailableStateList> RoleAuthorityAvailableStateList { get; set; } = new List<RoleAuthorityAvailableStateList>();

}