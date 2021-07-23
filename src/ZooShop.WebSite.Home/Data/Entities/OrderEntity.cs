using System;
using System.Collections.Generic;

namespace ZooShop.Website.Home.Data.Entities
{
    public class OrderEntity
    {
        public OrderEntity()
        {
            OrderItems = new HashSet<OrderItemEntity>();
            Products = new HashSet<ProductEntity>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? StatusId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Flat { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual OrderStatusEntity Status { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual ICollection<OrderItemEntity> OrderItems { get; set; }
        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}
