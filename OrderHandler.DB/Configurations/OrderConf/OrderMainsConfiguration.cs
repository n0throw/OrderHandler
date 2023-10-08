using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data.OrderAdd;

namespace OrderHandler.DB.Configurations.OrderConf; 

public class OrderMainsConfiguration : IEntityTypeConfiguration<OrderMain> {
	public void Configure(EntityTypeBuilder<OrderMain> builder) {
		builder.HasKey(e => e.Id).HasName("orderMain_pKey");

		builder.ToTable("orderMain");

		builder.Property(e => e.Id).HasColumnName("id");
		builder.Property(e => e.DeliveryDate)
			.HasColumnType("timestamp without time zone")
			.HasColumnName("dDeliveryDate");
		builder.Property(e => e.OrderDate)
			.HasColumnType("timestamp without time zone")
			.HasColumnName("dOrderDate");
		builder.Property(e => e.IdOrder).HasColumnName("IdOrder");
		builder.Property(e => e.IdUser).HasColumnName("idUser");
		builder.Property(e => e.OrderAmount)
			.HasPrecision(12, 4)
			.HasColumnName("nOrderAmount");
		builder.Property(e => e.Term)
			.HasPrecision(12, 4)
			.HasColumnName("nTerm");
		builder.Property(e => e.OrderNumber).HasColumnName("sOrderNumber");
		builder.Property(e => e.ProductType).HasColumnName("sProductType");

		builder.HasOne(d => d.Order)
			.WithOne(p => p.OrderMain)
			.HasForeignKey<OrderMain>(d => d.IdOrder)
			.HasConstraintName("orderMain_idOrder_fKey");

		builder.HasOne(d => d.User)
			.WithMany(p => p.OrderMains)
			.HasForeignKey(d => d.IdUser)
			.HasConstraintName("orderMain_idUser_fKey");
	}
}