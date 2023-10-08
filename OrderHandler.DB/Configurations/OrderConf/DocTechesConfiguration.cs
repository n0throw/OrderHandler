using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data.OrderAdd;

namespace OrderHandler.DB.Configurations.OrderConf; 

public class DocTechesConfiguration : IEntityTypeConfiguration<DocTech> {
	public void Configure(EntityTypeBuilder<DocTech> builder) {
		builder.HasKey(e => e.Id).HasName("docTech_pKey");

		builder.ToTable("docTech");

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
			.WithOne(p => p.DocTech)
			.HasForeignKey<DocTech>(d => d.IdOrder)
			.HasConstraintName("docTech_idOrder_fKey");

		builder.HasOne(d => d.User)
			.WithMany(p => p.DocTeches)
			.HasForeignKey(d => d.IdUser)
			.HasConstraintName("docTech_idUser_fKey");
	}
}