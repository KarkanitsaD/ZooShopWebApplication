using System.Collections.Generic;

namespace ZooShop.Website.Home.Data.Entities
{
    public class CategoryEntity : Entity
    {
        public CategoryEntity()
        {
            Products = new HashSet<ProductEntity>();
        }

        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<ProductEntity> Products { get; set; }
    }
}
