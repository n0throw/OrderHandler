using System.ComponentModel.DataAnnotations.Schema;

namespace OrderHandler.DB.Data.RoleAdd; 

public class RoleAuthorityList {
	public long Id { get; set; }

	public long? IdRoleAuthority { get; set; }

	[ForeignKey("IdRoleAuthority")]
	public RoleAuthority? RoleAuthority { get; set; }

	public long? IdRoleAuthorityAvailableStateList { get; set; }
	
	[ForeignKey("IdRoleAuthorityAvailableStateList")]
	public RoleAuthorityAvailableStateList? RoleAuthorityAvailableStateList { get; set; }

}