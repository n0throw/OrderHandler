using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data.OrderAdd;

namespace OrderHandler.DB.Configurations.OrderConf; 

public class GrindingsConfiguration : IEntityTypeConfiguration<Grinding> {
	public void Configure(EntityTypeBuilder<Grinding> builder) {
		builder.HasKey(e => e.Id).HasName("grinding_pKey");

		builder.ToTable("grinding");

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
			.WithOne(p => p.Grinding)
			.HasForeignKey<Grinding>(d => d.IdOrder)
			.HasConstraintName("grinding_idOrder_fKey");

		builder.HasOne(d => d.User)
			.WithMany(p => p.Grindings)
			.HasForeignKey(d => d.IdUser)
			.HasConstraintName("grinding_idUser_fKey");
	}
}