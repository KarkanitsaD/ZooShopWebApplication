using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooShop.Website.Home.Business.Models
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public string ProductTitle { get; set; }
        public int Quantity { get; set; }
    }
}
