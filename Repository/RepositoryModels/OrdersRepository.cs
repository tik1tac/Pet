using Contract.IRepositoryModels;
using Repository;

public class OrdersRepository : RepositoryBase<OrdersEntity>, IOrdersRepository
{
    public OrdersRepository(AplicationContext _context) : base(_context)
    {
    }
}
