using eCommerce.Domain.Entities.Products;
using eCommerce.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.DAL.Contexts
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string query = "Server=(localdb)\\MSSQLLocalDB;" +
                           "Database=eCommerceDb;" +
                           "Trusted_Connection=true";
            optionsBuilder.UseSqlServer(query);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
