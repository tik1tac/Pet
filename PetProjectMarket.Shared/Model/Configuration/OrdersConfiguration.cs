using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OrdersConfiguration : IEntityTypeConfiguration<OrdersEntity>
{
    public void Configure(EntityTypeBuilder<OrdersEntity> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(x => x.Id)
    .ValueGeneratedOnAdd();

        builder.HasOne(p => p.User)
            .WithMany(p => p.Orders)
            .HasForeignKey(p => p.IdUser);

    }
}