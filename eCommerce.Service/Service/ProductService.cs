using eCommerce.DAL.IRepositories;
using eCommerce.DAL.Repositories;
using eCommerce.Domain.Entities.Products;
using eCommerce.Service.DTOs.Products;
using eCommerce.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Service.Service
{
    public class ProductService : IProductService
    {
        //added dependency injection
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<Product> CreateServiceAsync(ProductCreationDto dto)
        {
            var product = new Product
            {
                ProductName = dto.ProductName,
                Description = dto.Description,
                Category = dto.Category,
                Count = dto.Count,
                CreatedAt = DateTime.UtcNow,
                FirmName = dto.FirmName,
                Price = dto.Price,
            };

            await productRepository.InsertAsync(product);
            return product;
        }

        public async Task<bool> DeleteServiceAsync(Predicate<Product> predicate)
        {
            var products = await productRepository.GetAllAsync().ToListAsync();
            var userToDelete = products.FirstOrDefault(product => predicate(product));
            if (userToDelete == null)
                return false;

            await productRepository.DeleteAsync(userToDelete.Id);
            return true;
        }

        public async Task<List<Product>> GetServiceAllAsync(Predicate<Product> predicate)
        {
            var products = await productRepository.GetAllAsync().ToListAsync();

            return products.Where(product => predicate(product)).ToList();
        }

        public async Task<Product> GetServiceAsync(Predicate<Product> predicate)
        {
            var products = await productRepository.GetAllAsync().ToListAsync();

            return products.FirstOrDefault(p => predicate(p));
        }

        public async Task<Product> UpdateServiceAsync(Predicate<Product> predicate, ProductCreationDto dto)
        {
            var products = await productRepository.GetAllAsync().ToListAsync();
            var update = products.FirstOrDefault(p => predicate(p));
            if (update is null)
                return null;

            update.Price = dto.Price;
            update.UpdatedAt = DateTime.UtcNow;
            update.Category = dto.Category;
            update.Description = dto.Description;
            update.Count = dto.Count;
            update.ProductName = dto.ProductName;
            update.FirmName = dto.FirmName;

            await productRepository.UpdateAsync(update);
            return update;
        }
    }
}
