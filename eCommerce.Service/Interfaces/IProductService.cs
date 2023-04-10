using eCommerce.Domain.Entities.Products;
using eCommerce.Service.DTOs.Products;

namespace eCommerce.Service.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateServiceAsync(ProductCreationDto dto);
        Task<Product> UpdateServiceAsync(Predicate<Product> predicate, ProductCreationDto dto);
        Task<bool> DeleteServiceAsync(Predicate<Product> predicate);
        Task<Product> GetServiceAsync(Predicate<Product> predicate);
        Task<List<Product>> GetServiceAllAsync(Predicate<Product> predicate);
    }
}
