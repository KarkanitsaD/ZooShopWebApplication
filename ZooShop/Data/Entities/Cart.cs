using System.Collections.Generic;

namespace ZooShop.Data.Entities
{
    public class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
            Products = new HashSet<Product>();
        }

        public long Id { get; set; }
        public long UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
