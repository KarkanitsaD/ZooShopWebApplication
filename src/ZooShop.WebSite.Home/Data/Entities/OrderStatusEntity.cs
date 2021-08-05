using System.Collections.Generic;

namespace ZooShop.Website.Home.Data.Entities
{
    public class OrderStatusEntity : Entity
    {
        public OrderStatusEntity()
        {
            Orders = new HashSet<OrderEntity>();
        }

        public string Title { get; set; }

        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}
