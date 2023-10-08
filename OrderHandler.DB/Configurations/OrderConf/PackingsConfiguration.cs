using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data.OrderAdd;

namespace OrderHandler.DB.Configurations.OrderConf; 

public class PackingsConfiguration : IEntityTypeConfiguration<Packing> {
	public void Configure(EntityTypeBuilder<Packing> builder) {
		builder.HasKey(e => e.Id).HasName("packing_pKey");

		builder.ToTable("packing");

		builder.Property(e => e.Id).HasColumnName("id");
		builder.Property(e => e.DateOfCompletion)
			.HasColumnType("timestamp without time zone")
			.HasColumnName("dDateOfCompletion");
		
		builder.Property(e => e.PlannedDate)
			.HasColumnType("timestamp without time zone")
			.HasColumnName("dPlannedDate");
		
		builder.
			Property(e => e.AreaOfLCBOrMDF)
			.HasPrecision(12, 4)
			.HasColumnName("nAreaOfLCBOrMDF");
		
		builder.Property(e => e.IdOrder)
			.HasColumnName("IdOrder");
		builder.Property(e => e.IdUser)
			.HasColumnName("IdUser");
		
		builder.HasOne(d => d.Order)
			.WithOne(p => p.Packing)
			.HasForeignKey<Packing>(d => d.IdOrder)
			.HasConstraintName("packing_idOrder_fKey");

		builder.HasOne(d => d.User)
			.WithMany(p => p.Packings)
			.HasForeignKey(d => d.IdUser)
			.HasConstraintName("packing_idUser_fKey");
	}
}