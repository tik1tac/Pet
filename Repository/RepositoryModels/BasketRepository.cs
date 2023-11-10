using Contract.IRepositoryModels;
using Repository;

public class BasketRepository : RepositoryBase<Basket>, IBasketRepository
{
    public BasketRepository(AplicationContext _context) : base(_context)
    {
    }
}
