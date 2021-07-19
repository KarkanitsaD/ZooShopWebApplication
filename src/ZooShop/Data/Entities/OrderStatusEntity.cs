using System.Collections.Generic;

namespace ZooShop.Data.Entities
{
    public class OrderStatusEntity
    {
        public OrderStatusEntity()
        {
            Orders = new HashSet<OrderEntity>();
        }

        public byte Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}
