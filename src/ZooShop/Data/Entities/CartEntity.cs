using System.Collections.Generic;

namespace ZooShop.Data.Entities
{
    public class CartEntity
    {
        public CartEntity()
        {
            CartItems = new HashSet<CartItemEntity>();
            Products = new HashSet<ProductEntity>();
        }

        public long Id { get; set; }
        public long UserId { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual ICollection<CartItemEntity> CartItems { get; set; }
        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}
