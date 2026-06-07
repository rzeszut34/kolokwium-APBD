using kolosAPBD.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolosAPBD.Configurations;

public class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
{
    public void Configure(EntityTypeBuilder<Tournament> builder)
    {
        builder.HasKey(x => x.TournamentId);
        builder.Property(x => x.TournamentId).IsRequired();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.StartDate).IsRequired().HasColumnType("datetime");
        builder.Property(x => x.EndDate).IsRequired().HasColumnType("datetime");
        
        builder.ToTable("Tournament");
    }
}