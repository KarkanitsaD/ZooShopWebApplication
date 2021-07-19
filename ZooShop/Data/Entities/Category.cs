using System.Collections.Generic;

namespace ZooShop.Data.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
