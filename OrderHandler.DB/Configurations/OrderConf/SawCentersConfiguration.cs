using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data.OrderAdd;

namespace OrderHandler.DB.Configurations.OrderConf; 

public class SawCentersConfiguration : IEntityTypeConfiguration<SawCenter> {
	public void Configure(EntityTypeBuilder<SawCenter> builder) {
		builder.HasKey(e => e.Id).HasName("sawCenter_pKey");

		builder.ToTable("sawCenter");

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
			.WithOne(p => p.SawCenter)
			.HasForeignKey<SawCenter>(d => d.IdOrder)
			.HasConstraintName("sawCenter_idOrder_fKey");

		builder.HasOne(d => d.User)
			.WithMany(p => p.SawCenters)
			.HasForeignKey(d => d.IdUser)
			.HasConstraintName("sawCenter_idUser_fKey");
	}
}