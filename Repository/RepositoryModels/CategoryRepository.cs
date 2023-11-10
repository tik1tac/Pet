using Contract.IRepositoryModels;
using Repository;

public class CategoryRepository : RepositoryBase<CategoryProductsEntity>, ICategoryRepository
{
    public CategoryRepository(AplicationContext _context) : base(_context)
    {
    }
}