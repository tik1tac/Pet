using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PetProjectMarket.Shared.Model.Configuration
{
    public class ProductsConfiguration : IEntityTypeConfiguration<ProductsEntity>
    {
        public void Configure(EntityTypeBuilder<ProductsEntity> builder)
        {
            builder
           .HasMany(p => p.Orders)
           .WithMany(p => p.Product)
           .UsingEntity<Basket>
           (j =>
               j
               .HasOne(p => p.Order)
               .WithMany(p => p.Basket)
               .HasForeignKey(p => p.IdOrder),
           j =>
               j
               .HasOne(p => p.Products)
               .WithMany(p => p.Basket)
               .HasForeignKey(p => p.IdProduct),
           j =>
           {
               j.HasKey(p => new { p.IdOrder, p.IdProduct });
               j.ToTable("Basket");
           }
           );
            builder
    .HasOne(p => p.Supplier)
    .WithMany(p => p.Products)
    .HasForeignKey(p => p.IdSupplier);

            builder.HasKey(p => p.Id);
            builder.Property(x => x.Id)
    .ValueGeneratedOnAdd();
        }
    }
}