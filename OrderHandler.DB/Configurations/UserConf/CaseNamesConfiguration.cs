using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderHandler.DB.Data.UserAdd;

namespace OrderHandler.DB.Configurations.UserConf; 

public class CaseNamesConfiguration : IEntityTypeConfiguration<CaseName> {
	public void Configure(EntityTypeBuilder<CaseName> builder) {
		builder.HasKey(e => e.Id).HasName("casename_pkey");

		builder.ToTable("casename");

		builder.Property(e => e.Id).HasColumnName("id");
		builder.Property(e => e.AblativeFirstName).HasColumnName("sAblative_firstName");
		builder.Property(e => e.AblativeMiddleName).HasColumnName("sAblative_middleName");
		builder.Property(e => e.AblativeLastName).HasColumnName("sAblative_lastName");
		
		builder.Property(e => e.AccusativeFirstName).HasColumnName("sAccusative_firstName");
		builder.Property(e => e.AccusativeMiddleName).HasColumnName("sAccusative_middleName");
		builder.Property(e => e.AccusativeLastName).HasColumnName("sAccusative_lastName");
		
        builder.Property(e => e.DativeFirstName).HasColumnName("sDative_firstName");
		builder.Property(e => e.DativeMiddleName).HasColumnName("sDative_middleName");
        builder.Property(e => e.DativeLastName).HasColumnName("sDative_lastName");
		
        builder.Property(e => e.GenitiveFirstName).HasColumnName("sGenitive_firstName");
		builder.Property(e => e.GenitiveMiddleName).HasColumnName("sGenitive_middleName");
        builder.Property(e => e.GenitiveLastName).HasColumnName("sGenitive_lastName");
		
        builder.Property(e => e.NominativeFirstName).HasColumnName("sNominative_firstName");
		builder.Property(e => e.NominativeMiddleName).HasColumnName("sNominative_middleName");
        builder.Property(e => e.NominativeLastName).HasColumnName("sNominative_lastName");
		
        builder.Property(e => e.PrepositionalFirstName).HasColumnName("sPrepositional_firstName");
		builder.Property(e => e.PrepositionalMiddleName).HasColumnName("sPrepositional_middleName");
        builder.Property(e => e.PrepositionalLastName).HasColumnName("sPrepositional_lastName");
	}
}