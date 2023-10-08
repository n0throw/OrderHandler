using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data.OrderAdd;

namespace OrderHandler.DB.Configurations.OrderConf; 

public class MillingsConfiguration : IEntityTypeConfiguration<Milling> {
	public void Configure(EntityTypeBuilder<Milling> builder) {
		builder.HasKey(e => e.Id).HasName("milling_pKey");

		builder.ToTable("milling");

		builder.Property(e => e.Id).HasColumnName("id");
		builder.Property(e => e.DateOfCompletion)
			.HasColumnType("timestamp without time zone")
			.HasColumnName("dDateOfCompletion");
		
		builder.Property(e => e.PlannedDate)
			.HasColumnType("timestamp without time zone")
			.HasColumnName("dPlannedDate");
		
		builder.
			Property(e => e.AreaOfMDF)
			.HasPrecision(12, 4)
			.HasColumnName("nAreaOfMDF");
		
		builder.Property(e => e.IdOrder)
			.HasColumnName("IdOrder");
		builder.Property(e => e.IdUser)
			.HasColumnName("IdUser");
		
		builder.HasOne(d => d.Order)
			.WithOne(p => p.Milling)
			.HasForeignKey<Milling>(d => d.IdOrder)
			.HasConstraintName("milling_idOrder_fKey");

		builder.HasOne(d => d.User)
			.WithMany(p => p.Millings)
			.HasForeignKey(d => d.IdUser)
			.HasConstraintName("milling_idUser_fKey");
	}
}