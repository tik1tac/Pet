using Contract;
using Contract.IRepositoryModels;
using FluentEmail.Core;
using PetProjectMarket.Shared.Helpers;
using Repository;

public class RepositoryWrapper : IRepositoryWrapper
{
    protected readonly AplicationContext context;

    public ISortHelpers<UserEntity> UserSort;

    public ISortHelpers<ProductsEntity> ProductSort;

    public IFluentEmail fluent;
    public RepositoryWrapper(AplicationContext _context, ISortHelpers<UserEntity> _usersort, ISortHelpers<ProductsEntity> _productsort, IFluentEmail _fluent) =>
        (context, UserSort, ProductSort, fluent) = (_context, _usersort, _productsort, _fluent);
    private IBasketRepository _basket;

    private IBonusRepository _bonus;

    private ICategoryRepository _category;

    private IEmployeeRepository _employee;

    private IGeoZoneRepository _geozone;

    private IImagesRepository _image;

    private IOrdersRepository _orders;

    private IProductsRepository _product;

    private ISuppliersRepository _supplier;

    private IUserRepository _user;

    private IServiceEmail _email;
    public IBasketRepository Basket => _basket ?? new BasketRepository(context);

    public IBonusRepository Bonus => _bonus ?? new BonusRepository(context);

    public ICategoryRepository Category => _category ?? new CategoryRepository(context);

    public IEmployeeRepository Employee => _employee ?? new EmployeeRepository(context);

    public IGeoZoneRepository GeoZone => _geozone ?? new GeoZoneRepository(context);

    public IImagesRepository Image => _image ?? new ImageRepository(context);

    public IOrdersRepository Orders => _orders ?? new OrdersRepository(context);

    public ISuppliersRepository Supplier => _supplier ?? new SuppliersRepository(context);

    public IUserRepository User => _user ?? new UserRepository(context);

    public IServiceEmail Email => _email ?? new ServiceEmail(fluent);

    public IProductsRepository Product => _product ?? new ProductsRepository(context,ProductSort);

    public async Task SaveAsync() => await context.SaveChangesAsync();
}