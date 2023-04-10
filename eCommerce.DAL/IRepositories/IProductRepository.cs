using eCommerce.Domain.Entities.Products;

namespace eCommerce.DAL.IRepositories
{
    public interface IProductRepository
    {
        ValueTask<Product> InsertAsync(Product product);
        ValueTask<Product> UpdateAsync(Product product);
        ValueTask<bool> DeleteAsync(long id);
        ValueTask<Product> GetAsync(Predicate<Product> predicate = null);
        IQueryable<Product> GetAllAsync(Predicate<Product> predicate = null);
    }
}
