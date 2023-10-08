using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data.RoleAdd;

namespace OrderHandler.DB.Configurations.RoleConf; 

public class RoleAuthoritiesConfiguration : IEntityTypeConfiguration<RoleAuthority> {
	public void Configure(EntityTypeBuilder<RoleAuthority> builder) {
		builder.HasKey(e => e.Id).HasName("roleAuthority_pKey");

		builder.ToTable("roleAuthority");

		builder.Property(e => e.Id).HasColumnName("id");
		builder.Property(e => e.IdRole).HasColumnName("idRole");

		builder.HasOne(d => d.Role)
			.WithMany(p => p.RoleAuthorities)
			.HasForeignKey(d => d.IdRole)
			.HasConstraintName("roleAuthority_idRole_fKey");
	}
}