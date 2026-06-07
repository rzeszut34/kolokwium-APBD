using kolosAPBD.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolosAPBD.Configurations;

public class PlayerMatchConfiguration : IEntityTypeConfiguration<PlayerMatch>
{
    public void Configure(EntityTypeBuilder<PlayerMatch> builder)
    {
        builder.HasKey(x => new { x.MatchId, x.PlayerId });
        builder.Property(x => x.MatchId).IsRequired();
        builder.Property(x => x.PlayerId).IsRequired();
        builder.Property(x => x.Mvps).IsRequired();
        builder.Property(x => x.Rating).IsRequired().HasColumnType("decimal(4,2)");
        
        builder.HasOne(x => x.Match)
            .WithMany(x => x.PlayerMatches)
            .HasForeignKey(x => x.MatchId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Player)
            .WithMany(x => x.PlayerMatches)
            .HasForeignKey(x => x.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.ToTable("Player_Match");
    }
}