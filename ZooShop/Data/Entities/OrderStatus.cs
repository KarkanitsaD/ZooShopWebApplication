using System.Collections.Generic;

namespace ZooShop.Data.Entities
{
    public class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }

        public byte Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
