﻿using System;
using System.Collections.Generic;

namespace ZooShop.Website.Home.Data.Entities
{
    public class UserEntity
    {
        public UserEntity()
        {
            Orders = new HashSet<OrderEntity>();
            CartItems = new HashSet<CartItemEntity>();
            Products = new HashSet<ProductEntity>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime RegisteredAt { get; set; }


        public virtual ICollection<CartItemEntity> CartItems { get; set; }
        public virtual ICollection<OrderEntity> Orders { get; set; }
        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}
