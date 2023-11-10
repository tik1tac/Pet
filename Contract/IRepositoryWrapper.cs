using Contract;
using Contract.IRepositoryModels;

public interface IRepositoryWrapper
{
    IBasketRepository Basket { get; }
    IBonusRepository Bonus { get; }
    ICategoryRepository Category { get; }
    IEmployeeRepository Employee { get; }
    IGeoZoneRepository GeoZone { get; }
    IImagesRepository Image { get; }
    IOrdersRepository Orders { get; }
    IProductsRepository Product { get; }
    ISuppliersRepository Supplier { get; }
    IUserRepository User { get; }
    IServiceEmail Email { get; }
    Task SaveAsync();
}