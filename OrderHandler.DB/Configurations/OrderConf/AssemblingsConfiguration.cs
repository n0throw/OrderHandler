using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data.OrderAdd;

namespace OrderHandler.DB.Configurations.OrderConf; 

public class AssemblingsConfiguration : IEntityTypeConfiguration<Assembling> {
	public void Configure(EntityTypeBuilder<Assembling> builder) {
		builder.HasKey(e => e.Id).HasName("assembling_pKey");
		builder.ToTable("assembling");

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
			.WithOne(p => p.Assembling)
			.HasForeignKey<Assembling>(d => d.IdOrder)
			.HasConstraintName("assembling_idOrder_fKey");

		builder.HasOne(d => d.User)
			.WithMany(p => p.Assemblings)
			.HasForeignKey(d => d.IdUser)
			.HasConstraintName("assembling_idUser_fKey");
	}
}