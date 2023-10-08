using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data.OrderAdd;

namespace OrderHandler.DB.Configurations.OrderConf; 

public class AdditivesConfiguration : IEntityTypeConfiguration<Additive> {
	public void Configure(EntityTypeBuilder<Additive> builder) {
		builder.HasKey(e => e.Id).HasName("additive_pKey");
		builder.ToTable("additive");

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
			.WithOne(p => p.Additive)
			.HasForeignKey<Additive>(d => d.IdOrder)
			.HasConstraintName("additive_idOrder_fKey");

		builder.HasOne(d => d.User)
			.WithMany(p => p.Additives)
			.HasForeignKey(d => d.IdUser)
			.HasConstraintName("additive_idUser_fKey");
	}
}