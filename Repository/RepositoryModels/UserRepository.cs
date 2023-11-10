using Contract.IRepositoryModels;
using Repository;

public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
{
    public UserRepository(AplicationContext _context) : base(_context)
    {
    }


    public async Task<UserEntity> GetByEmail(string email) =>
        (await GetByCondition(p => p.Email.Equals(email))).FirstOrDefault();
}