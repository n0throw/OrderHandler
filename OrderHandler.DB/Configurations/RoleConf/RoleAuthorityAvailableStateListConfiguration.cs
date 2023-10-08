using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data.RoleAdd;

namespace OrderHandler.DB.Configurations.RoleConf; 

public class RoleAuthorityAvailableStateListConfiguration : IEntityTypeConfiguration<RoleAuthorityAvailableStateList> {
	public void Configure(EntityTypeBuilder<RoleAuthorityAvailableStateList> builder) {
		builder.HasKey(e => e.Id).HasName("roleAuthorityAvailableStateList_pKey");

		builder.ToTable("roleAuthorityAvailableStateList");

		builder.Property(e => e.Id).HasColumnName("id");
		builder.Property(e => e.IdRoleAuthorityStateList)
			.HasColumnName("idRoleAuthorityAvailableStateList");

		builder.HasOne(d => d.RoleAuthorityStateList)
			.WithMany(p => p.RoleAuthorityAvailableStateList)
			.HasForeignKey(d => d.IdRoleAuthorityStateList)
			.HasConstraintName("RoleAuthorityAvailableStateList_idRoleAuthorityStateList_fKey");
	}
}