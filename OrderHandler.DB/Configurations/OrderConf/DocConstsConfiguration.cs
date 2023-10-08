using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data.OrderAdd;

namespace OrderHandler.DB.Configurations.OrderConf; 

public class DocConstsConfiguration : IEntityTypeConfiguration<DocConst> {
	public void Configure(EntityTypeBuilder<DocConst> builder) {
		builder.HasKey(e => e.Id).HasName("docConst_pKey");

		builder.ToTable("docConst");

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
			.WithOne(p => p.DocConst)
			.HasForeignKey<DocConst>(d => d.IdOrder)
			.HasConstraintName("docConst_idOrder_fKey");

		builder.HasOne(d => d.User)
			.WithMany(p => p.DocConsts)
			.HasForeignKey(d => d.IdUser)
			.HasConstraintName("docConst_idUser_fKey");
	}
}