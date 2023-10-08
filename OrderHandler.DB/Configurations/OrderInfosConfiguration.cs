using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data;

namespace OrderHandler.DB.Configurations; 

public class OrderInfosConfiguration : IEntityTypeConfiguration<OrderInfo> {
	public void Configure(EntityTypeBuilder<OrderInfo> builder) {
		builder.HasKey(e => e.Id).HasName("orderInfo_pKey");

		builder.ToTable("orderInfo");

		builder.Property(e => e.Id).HasColumnName("id");
		builder.Property(e => e.Note).HasColumnName("sNote");
	}
}