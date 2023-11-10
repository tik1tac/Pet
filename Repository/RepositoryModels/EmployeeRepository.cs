using Contract.IRepositoryModels;
using Repository;

public class EmployeeRepository : RepositoryBase<EmployeeEntity>, IEmployeeRepository
{
    public EmployeeRepository(AplicationContext _context) : base(_context)
    {
    }
}