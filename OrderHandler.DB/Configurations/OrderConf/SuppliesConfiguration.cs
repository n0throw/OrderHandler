using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data.OrderAdd;

namespace OrderHandler.DB.Configurations.OrderConf; 

public class SuppliesConfiguration : IEntityTypeConfiguration<Supply> {
	public void Configure(EntityTypeBuilder<Supply> builder) {
		builder.HasKey(e => e.Id).HasName("supply_pKey");

		builder.ToTable("supply");

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
			.WithOne(p => p.Supply)
			.HasForeignKey<Supply>(d => d.IdOrder)
			.HasConstraintName("supply_idOrder_fKey");

		builder.HasOne(d => d.User)
			.WithMany(p => p.Supplies)
			.HasForeignKey(d => d.IdUser)
			.HasConstraintName("supply_idUser_fKey");
	}
}