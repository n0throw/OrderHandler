using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data.OrderAdd;

namespace OrderHandler.DB.Configurations.OrderConf; 

public class ShipmentsConfiguration : IEntityTypeConfiguration<Shipment> {
	public void Configure(EntityTypeBuilder<Shipment> builder) {
		builder.HasKey(e => e.Id).HasName("shipment_pKey");

		builder.ToTable("shipment");

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
			.WithOne(p => p.Shipment)
			.HasForeignKey<Shipment>(d => d.IdOrder)
			.HasConstraintName("shipment_idOrder_fKey");

		builder.HasOne(d => d.User)
			.WithMany(p => p.Shipments)
			.HasForeignKey(d => d.IdUser)
			.HasConstraintName("shipment_idUser_fKey");
	}
}