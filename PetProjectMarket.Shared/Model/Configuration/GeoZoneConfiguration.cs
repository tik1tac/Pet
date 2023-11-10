using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class GeoZoneConfiguration : IEntityTypeConfiguration<GeoZoneEntitity>
{
    public void Configure(EntityTypeBuilder<GeoZoneEntitity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
    .ValueGeneratedOnAdd();
    }
}
