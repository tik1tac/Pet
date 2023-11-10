using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BonusConfiguration : IEntityTypeConfiguration<BonusEntity>
{
    public void Configure(EntityTypeBuilder<BonusEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.HasOne(p => p.Product)
            .WithMany(p => p.Bonus)
            .HasForeignKey(p => p.IdProduct);

    }
}
