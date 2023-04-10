using eCommerce.Domain.Entities.Users;
using eCommerce.Service.DTOs.Users;

namespace eCommerce.Service.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateServiceAsync(UserCreationDto dto);
        Task<User> UpdateServiceAsync(Predicate<User> predicate, UserCreationDto dto);
        Task<bool> DeleteServiceAsync(Predicate<User> predicate);
        Task<User> GetServiceAsync(Predicate<User> predicate);
        Task<List<User>> GetServiceAllAsync(Predicate<User> predicate);
    }
}
