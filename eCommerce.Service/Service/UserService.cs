using eCommerce.DAL.IRepositories;
using eCommerce.DAL.Repositories;
using eCommerce.Domain.Entities.Users;
using eCommerce.Service.DTOs.Users;
using eCommerce.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<User> CreateServiceAsync(UserCreationDto dto)
        {
            var user = new User()
            {
                Age = dto.Age,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                CreatedAt = DateTime.UtcNow,
                Phone = dto.Phone,
                Role = dto.Role,
                Password = dto.Password
            };

            await userRepository.InsertAsync(user);
            return user;
        }

        public async Task<bool> DeleteServiceAsync(Predicate<User> predicate)
        {
            var users = await userRepository.GetAllAsync().ToListAsync();

            var userToDelete = users.FirstOrDefault(user => predicate(user));

            if (userToDelete == null)
                return false;

            await userRepository.DeleteAsync(userToDelete.Id);

            return true;
        }

        public async Task<List<User>> GetServiceAllAsync(Predicate<User> predicate)
        {
            var users = await userRepository.GetAllAsync().ToListAsync();

            return users.Where(user => predicate(user)).ToList();
        }

        public async Task<User> GetServiceAsync(Predicate<User> predicate)
        {
            var users = await userRepository.GetAllAsync().ToListAsync();

            return users.FirstOrDefault(p => predicate(p));
        }

        public async Task<User> UpdateServiceAsync(Predicate<User> predicate, UserCreationDto dto)
        {
            var users = await userRepository.GetAllAsync().ToListAsync();

            var update  = users.FirstOrDefault(user => predicate(user));
            if (update is null)
                return null;

            update.Phone = dto.Phone;
            update.FirstName = dto.FirstName;
            update.LastName = dto.LastName;
            update.Age = dto.Age;
            update.UpdatedAt = DateTime.UtcNow;
            update.Password = dto.Password;

            await userRepository.UpdateAsync(update);
            return update;
        }
    }
}
