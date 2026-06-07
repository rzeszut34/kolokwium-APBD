using kolosAPBD.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolosAPBD.Configurations;

public class MatchConfiguration : IEntityTypeConfiguration<Match>
{
    public void Configure(EntityTypeBuilder<Match> builder)
    {
        builder.HasKey(x => x.MatchId);
        builder.Property(x => x.MatchId).IsRequired();
        builder.Property(x => x.MatchDate).IsRequired().HasColumnType("datetime");
        builder.Property(x => x.Team1Score).IsRequired();
        builder.Property(x => x.Team2Score).IsRequired();
        builder.Property(x => x.BestRating).HasColumnType("decimal(4,2)");
        
        builder.HasOne(x => x.Map)
            .WithMany(x => x.Matches)
            .HasForeignKey(x => x.MapId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Tournament)
            .WithMany(x => x.Matches)
            .HasForeignKey(x => x.TournamentId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.ToTable("Match");
    }
}