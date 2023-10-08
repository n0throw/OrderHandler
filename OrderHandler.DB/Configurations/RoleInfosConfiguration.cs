using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data;

namespace OrderHandler.DB.Configurations; 

public class RoleInfosConfiguration : IEntityTypeConfiguration<RoleInfo> {
	public void Configure(EntityTypeBuilder<RoleInfo> builder) {
		builder.HasKey(e => e.Id).HasName("roleInfo_pKey");

		builder.ToTable("roleInfo");

		builder.Property(e => e.Id).HasColumnName("id");
		builder.Property(e => e.DateOfCreation)
			.HasColumnType("timestamp without time zone")
			.HasColumnName("dDateOfCreation");
		builder.Property(e => e.DateOfEditing)
			.HasColumnType("timestamp without time zone")
			.HasColumnName("dDateOfEditing");
		builder.Property(e => e.IdCreateUser).HasColumnName("IdCreateUser");
		builder.Property(e => e.IdLastEditUser).HasColumnName("IdLastEditUser");
		builder.Property(e => e.Name).HasColumnName("sName");

		builder.HasOne(d => d.CreateUser)
			.WithMany(p => p.CreatedRoles)
			.HasForeignKey(d => d.IdCreateUser)
			.HasConstraintName("roleInfo_idCreateUser_fKey");

		builder.HasOne(d => d.LastEditUser)
			.WithMany(p => p.EditedRoles)
			.HasForeignKey(d => d.IdLastEditUser)
			.HasConstraintName("roleInfo_idLastEditUser_fKey");
	}
}