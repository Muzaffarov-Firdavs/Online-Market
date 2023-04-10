using eCommerce.Domain.Commons;

namespace eCommerce.Service.DTOs.Products
{
    public class ProductDto : Auditable
    {
        public string ProductName { get; set; }
        public string FirmName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
