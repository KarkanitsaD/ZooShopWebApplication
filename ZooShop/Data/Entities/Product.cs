using System;
using System.Collections.Generic;


namespace ZooShop.Data.Entities
{
    public class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
            OrderItems = new HashSet<OrderItem>();
            Categories = new HashSet<Category>();
            Users = new HashSet<User>();
            Orders = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public short? Discount { get; set; }
        public int? Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        //public virtual ICollection<Cart> Carts { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }


        public ICollection<Category> Categories { get; set; }

    }
}
