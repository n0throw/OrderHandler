using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data.RoleAdd;

namespace OrderHandler.DB.Configurations.RoleConf; 

public class RoleAuthorityStateListConfiguration : IEntityTypeConfiguration<RoleAuthorityStateList> {
	public void Configure(EntityTypeBuilder<RoleAuthorityStateList> builder) {
		builder.HasKey(e => e.Id).HasName("roleAuthorityStateList_pKey");

		builder.ToTable("roleAuthorityStateList");

		builder.Property(e => e.Id).HasColumnName("id");
		builder.Property(e => e.Name).HasColumnName("sName");
		builder.Property(e => e.SystemName).HasColumnName("sSystemName");
	}
}