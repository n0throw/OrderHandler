using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data.RoleAdd;

namespace OrderHandler.DB.Configurations.RoleConf; 

public class RoleAuthorityListConfiguration : IEntityTypeConfiguration<RoleAuthorityList> {
	public void Configure(EntityTypeBuilder<RoleAuthorityList> builder) {
		builder.HasKey(e => e.Id).HasName("roleAuthorityList_pKey");

		builder.ToTable("roleAuthorityList");

		builder.Property(e => e.Id).HasColumnName("id");
		builder.Property(e => e.IdRoleAuthority)
			.HasColumnName("idRoleAuthority");
		builder.Property(e => e.IdRoleAuthorityAvailableStateList)
			.HasColumnName("idRoleAuthorityAvailableStateList");

		builder.HasOne(d => d.RoleAuthority)
			.WithMany(p => p.RoleAuthorityList)
			.HasForeignKey(d => d.IdRoleAuthority)
			.HasConstraintName("roleAuthorityList_idRoleAuthority_fKey");

		builder.HasOne(d => d.RoleAuthorityAvailableStateList)
			.WithMany(p => p.RoleAuthorityList)
			.HasForeignKey(d => d.IdRoleAuthorityAvailableStateList)
			.HasConstraintName("roleAuthorityList_idRoleAuthorityAvailableStateList_fKey");
	}
}