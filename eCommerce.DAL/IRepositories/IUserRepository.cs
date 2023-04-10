using eCommerce.Domain.Entities.Users;

namespace eCommerce.DAL.IRepositories
{
    public interface IUserRepository
    {
        ValueTask<User> InsertAsync(User user);
        ValueTask<User> UpdateAsync(User user);
        ValueTask<bool> DeleteAsync(long id);
        ValueTask<User> GetAsync(Predicate<User> predicate = null);
        IQueryable<User> GetAllAsync(Predicate<User> predicate = null);
    }
}
