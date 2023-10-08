using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data.OrderAdd;

namespace OrderHandler.DB.Configurations.OrderConf; 

public class MountingsConfiguration : IEntityTypeConfiguration<Mounting> {
	public void Configure(EntityTypeBuilder<Mounting> builder) {
		builder.HasKey(e => e.Id).HasName("mounting_pKey");

		builder.ToTable("mounting");

		builder.Property(e => e.Id).HasColumnName("id");
		builder.Property(e => e.DateOfCompletion)
			.HasColumnType("timestamp without time zone")
			.HasColumnName("dDateOfCompletion");
		
		builder.Property(e => e.PlannedDate)
			.HasColumnType("timestamp without time zone")
			.HasColumnName("dPlannedDate");

		builder.Property(e => e.IdOrder)
			.HasColumnName("IdOrder");
		builder.Property(e => e.IdUser)
			.HasColumnName("IdUser");
		
		builder.HasOne(d => d.Order)
			.WithOne(p => p.Mounting)
			.HasForeignKey<Mounting>(d => d.IdOrder)
			.HasConstraintName("mounting_idOrder_fKey");

		builder.HasOne(d => d.User)
			.WithMany(p => p.Mountings)
			.HasForeignKey(d => d.IdUser)
			.HasConstraintName("mounting_idUser_fKey");
	}
}