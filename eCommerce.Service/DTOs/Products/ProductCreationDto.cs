namespace eCommerce.Service.DTOs.Products
{
    public class ProductCreationDto
    {
        public long? Id { get; set; }
        public string ProductName { get; set; }
        public string FirmName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public long UserId { get; set; }
    }
}
