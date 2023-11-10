namespace Contract.IRepositoryModels;

public interface IUserRepository : IRepositoryBase<UserEntity>
{
    Task<UserEntity> GetByEmail(string email);
}