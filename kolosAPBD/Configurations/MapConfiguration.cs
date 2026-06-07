using kolosAPBD.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolosAPBD.Configurations;

public class MapConfiguration : IEntityTypeConfiguration<Map>
{
    public void Configure(EntityTypeBuilder<Map> builder)
    {
        builder.HasKey(x => x.MapId);
        builder.Property(x => x.MapId).IsRequired();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Type).IsRequired().HasMaxLength(100);
        
        builder.ToTable("Map");
    }
}