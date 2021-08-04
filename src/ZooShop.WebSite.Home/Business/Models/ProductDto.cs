namespace ZooShop.Website.Home.Business.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public short? Discount { get; set; }
        public int? Quantity { get; set; }
    }
}
