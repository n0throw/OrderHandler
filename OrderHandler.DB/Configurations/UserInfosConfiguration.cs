using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data;

namespace OrderHandler.DB.Configurations; 

public class UserInfosConfiguration : IEntityTypeConfiguration<UserInfo> {
	public void Configure(EntityTypeBuilder<UserInfo> builder) {
		builder.HasKey(e => e.Id).HasName("userinfo_pkey");

		builder.ToTable("userinfo");

		builder.Property(e => e.Id).HasColumnName("id");
		builder.Property(e => e.DateOfCreation)
			.HasColumnType("timestamp without time zone")
			.HasColumnName("dDateOfCreation");
		builder.Property(e => e.DateOfEditing)
			.HasColumnType("timestamp without time zone")
			.HasColumnName("dDateOfEditing");
		builder.Property(e => e.IdCreateUser).HasColumnName("idCreateUser");
		builder.Property(e => e.IdLastEditUser).HasColumnName("idLastEditUser");
		builder.Property(e => e.IdRole).HasColumnName("idRole");
		builder.Property(e => e.Login).HasColumnName("sLogin");
		builder.Property(e => e.PasswordHash).HasColumnName("sPasswordHash");

		builder.HasOne(d => d.CreateUser)
			.WithMany(p => p.CreatedUsers)
			.HasForeignKey(d => d.IdCreateUser)
			.HasConstraintName("userInfo_idCreateUser_fKey");

		builder.HasOne(d => d.LastEditUser)
			.WithMany(p => p.EditedUsers)
			.HasForeignKey(d => d.IdLastEditUser)
			.HasConstraintName("userInfo_idLastEditUser_fKey");

		builder.HasOne(d => d.Role)
			.WithMany(p => p.Users)
			.HasForeignKey(d => d.IdRole)
			.HasConstraintName("userInfo_idRole_fKey");
		
		builder.HasOne(d => d.CaseName)
			.WithMany(p => p.UserInfos)
			.HasForeignKey(d => d.IdCaseName)
			.HasConstraintName("userInfo_idCaseName_fKey");
	}
}