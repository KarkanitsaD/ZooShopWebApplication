﻿
namespace ZooShop.Website.Home.Data.Entities
{
    public class OrderItemEntity : Entity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual OrderEntity Order { get; set; }
        public virtual ProductEntity Product { get; set; }
    }
}
