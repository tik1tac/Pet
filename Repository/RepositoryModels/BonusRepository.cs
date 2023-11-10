using Contract.IRepositoryModels;
using Repository;

public class BonusRepository : RepositoryBase<BonusEntity>, IBonusRepository
{
    public BonusRepository(AplicationContext _context) : base(_context)
    {
    }
}
