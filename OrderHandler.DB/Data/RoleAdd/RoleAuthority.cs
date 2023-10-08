using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderHandler.DB.Data.RoleAdd; 

public class RoleAuthority {
	public long Id { get; set; }

	public long? IdRole { get; set; }

	[ForeignKey("IdRole")]
	public RoleInfo? Role { get; set; }

	public ICollection<RoleAuthorityList> RoleAuthorityList { get; set; } = new List<RoleAuthorityList>();
}