using Contract.IRepositoryModels;
using Repository;

public class SuppliersRepository : RepositoryBase<SuppliersEntity>, ISuppliersRepository
{
    public SuppliersRepository(AplicationContext _context) : base(_context)
    {
    }
}