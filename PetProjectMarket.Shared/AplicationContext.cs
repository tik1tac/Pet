using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetProjectMarket.Shared.Model.Configuration;

public class AplicationContext : IdentityDbContext<UserEntity>
{
    public AplicationContext(DbContextOptions options)
    : base(options)
    {
    }
    //TODO
    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Configuration
        builder.ApplyConfiguration(new ProductsConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new BonusConfiguration());
        builder.ApplyConfiguration(new SuppliersConfiguration());
        builder.ApplyConfiguration(new CategoryConfiguration());
        //builder.ApplyConfiguration(new EmployeeConfiguration());
        builder.ApplyConfiguration(new RoleConfiguration());
        builder.ApplyConfiguration(new GeoZoneConfiguration());
        builder.ApplyConfiguration(new ImagesConfiguration());
        builder.ApplyConfiguration(new OrdersConfiguration());
        #endregion
        base.OnModelCreating(builder);
    }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<ProductsEntity> ProductsEntities { get; set; }
    public DbSet<UserEntity> UserEntities { get; set; }
    public DbSet<SuppliersEntity> SuppliersEntities { get; set; }
    public DbSet<BonusEntity> BonusEntities { get; set; }
    public DbSet<CategoryProductsEntity> CategoryProductsEntities { get; set; }
    public DbSet<EmployeeEntity> EmployeeEntities { get; set; }
    public DbSet<GeoZoneEntitity> GeoZonesEntities { get; set; }
    public DbSet<ImagesProductsEntity> ImagesProductsEntities { get; set; }
    public DbSet<OrdersEntity> OrdersEntities { get; set; }
}