using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SuppliersConfiguration : IEntityTypeConfiguration<SuppliersEntity>
{
    public void Configure(EntityTypeBuilder<SuppliersEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
    .ValueGeneratedOnAdd();
    }
}
