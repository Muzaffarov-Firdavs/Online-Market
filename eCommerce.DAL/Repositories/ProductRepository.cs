using eCommerce.DAL.Contexts;
using eCommerce.DAL.IRepositories;
using eCommerce.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eCommerce.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();
        public async ValueTask<bool> DeleteAsync(long id)
        {
            Product entity = await appDbContext.Products.FirstOrDefaultAsync(product => product.Id == id);
            if (entity is null)
                return false;
            appDbContext.Products.Remove(entity);
            await appDbContext.SaveChangesAsync();
            return true;
        }

        public IQueryable<Product> GetAllAsync(Predicate<Product> predicate = null)
        {
            if (predicate is null)
            {
                return appDbContext.Products;
            }
            return this.appDbContext.Products.AsEnumerable().Where(product => predicate(product)).AsQueryable();
        }

        public async ValueTask<Product> GetAsync(Predicate<Product> predicate = null)
        {
            var products = await appDbContext.Products.ToListAsync();
            return products.FirstOrDefault(product => predicate(product));
        }

        public async ValueTask<Product> InsertAsync(Product product)
        {
            var addedProduct = await appDbContext.Products.AddAsync(product);
            await appDbContext.SaveChangesAsync();
            return addedProduct.Entity;
        }

        public async ValueTask<Product> UpdateAsync(Product product)
        {
            EntityEntry<Product> entity = this.appDbContext.Products.Update(product);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }
    }
}
