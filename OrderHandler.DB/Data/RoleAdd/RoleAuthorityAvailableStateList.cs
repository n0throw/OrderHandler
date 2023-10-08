using System.Collections.Generic;

namespace OrderHandler.DB.Data.RoleAdd; 

public class RoleAuthorityAvailableStateList {
	public long Id { get; set; }

	public long? IdRoleAuthorityStateList { get; set; }

	public RoleAuthorityStateList? RoleAuthorityStateList { get; set; }

	public ICollection<RoleAuthorityList> RoleAuthorityList { get; set; } = new List<RoleAuthorityList>();

}