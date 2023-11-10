using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ImagesConfiguration : IEntityTypeConfiguration<ImagesProductsEntity>
{
    public void Configure(EntityTypeBuilder<ImagesProductsEntity> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(x => x.Id)
    .ValueGeneratedOnAdd();

        builder.HasOne(p => p.Product)
            .WithMany(p => p.Images)
            .HasForeignKey(p => p.IdProduct);
    }
}
