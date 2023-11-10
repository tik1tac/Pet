using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CategoryConfiguration : IEntityTypeConfiguration<CategoryProductsEntity>
{
    public void Configure(EntityTypeBuilder<CategoryProductsEntity> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(x => x.Id)
    .ValueGeneratedOnAdd();

        builder.HasOne(p => p.ProductsEntity)
            .WithMany(p => p.CategoryProducts)
            .HasForeignKey(p => p.IdProduct);
    }
}
