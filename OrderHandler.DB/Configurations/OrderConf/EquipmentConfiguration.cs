using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data.OrderAdd;

namespace OrderHandler.DB.Configurations.OrderConf; 

public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment> {
	public void Configure(EntityTypeBuilder<Equipment> builder) {
		builder.HasKey(e => e.Id).HasName("equipment_pKey");

		builder.ToTable("equipment");

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
			.WithOne(p => p.Equipment)
			.HasForeignKey<Equipment>(d => d.IdOrder)
			.HasConstraintName("equipment_idOrder_fKey");

		builder.HasOne(d => d.User)
			.WithMany(p => p.Equipments)
			.HasForeignKey(d => d.IdUser)
			.HasConstraintName("equipment_idUser_fKey");
	}
}