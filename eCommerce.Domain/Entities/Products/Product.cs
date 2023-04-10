using eCommerce.Domain.Commons;
using eCommerce.Domain.Entities.Users;

namespace eCommerce.Domain.Entities.Products
{
    public class Product : Auditable
    {
        public string ProductName { get; set; }
        public string FirmName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
