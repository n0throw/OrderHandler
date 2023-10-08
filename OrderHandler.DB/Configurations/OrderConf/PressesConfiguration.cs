using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data.OrderAdd;

namespace OrderHandler.DB.Configurations.OrderConf; 

public class PressesConfiguration : IEntityTypeConfiguration<Press> {
	public void Configure(EntityTypeBuilder<Press> builder) {
		builder.HasKey(e => e.Id).HasName("press_pKey");

		builder.ToTable("press");

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
			.WithOne(p => p.Press)
			.HasForeignKey<Press>(d => d.IdOrder)
			.HasConstraintName("press_idOrder_fKey");

		builder.HasOne(d => d.User)
			.WithMany(p => p.Presses)
			.HasForeignKey(d => d.IdUser)
			.HasConstraintName("press_idUser_fKey");
	}
}