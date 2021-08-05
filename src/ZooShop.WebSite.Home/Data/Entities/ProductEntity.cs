using System;
using System.Collections.Generic;


namespace ZooShop.Website.Home.Data.Entities
{
    public class ProductEntity : Entity
    {
        public ProductEntity()
        {
            CartItems = new HashSet<CartItemEntity>();
            OrderItems = new HashSet<OrderItemEntity>();
            Categories = new HashSet<CategoryEntity>();
            Users = new HashSet<UserEntity>();
            Orders = new HashSet<OrderEntity>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public short? Discount { get; set; }
        public int? Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<UserEntity> Users { get; set; }
        public virtual ICollection<CartItemEntity> CartItems { get; set; }

        public virtual ICollection<OrderEntity> Orders { get; set; }
        public virtual ICollection<OrderItemEntity> OrderItems { get; set; }


        public ICollection<CategoryEntity> Categories { get; set; }

    }
}
