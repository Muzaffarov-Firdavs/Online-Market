using eCommerce.DAL.Contexts;
using eCommerce.DAL.IRepositories;
using eCommerce.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eCommerce.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();
        public async ValueTask<bool> DeleteAsync(long id)
        {
            User entity = await appDbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (entity is null)
            {
                return false;
            }
            appDbContext.Remove(entity);
            await appDbContext.SaveChangesAsync();
            return true;
        }

        public IQueryable<User> GetAllAsync(Predicate<User> predicate = null)
        {
            if (predicate is null)
            {
                return appDbContext.Users;
            }
            return this.appDbContext.Users.AsEnumerable().Where(user => predicate(user)).AsQueryable();

        }

        public async ValueTask<User> GetAsync(Predicate<User> predicate = null)
        {
            var users = await appDbContext.Users.ToListAsync();
            return users.FirstOrDefault(user => predicate(user));
        }

        public async ValueTask<User> InsertAsync(User user)
        {
            var addedUser = await appDbContext.Users.AddAsync(user);
            await appDbContext.SaveChangesAsync();
            return addedUser.Entity;
        }

        public async ValueTask<User> UpdateAsync(User user)
        {
            EntityEntry<User> entity = this.appDbContext.Users.Update(user);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }
    }
}
