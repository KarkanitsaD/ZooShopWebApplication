using System.Collections.Generic;

namespace ZooShop.Website.Home.Data.Entities
{
    public class OrderStatusEntity
    {
        public OrderStatusEntity()
        {
            Orders = new HashSet<OrderEntity>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}
