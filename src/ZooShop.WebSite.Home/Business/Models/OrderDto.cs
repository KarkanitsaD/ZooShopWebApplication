using System;

namespace ZooShop.Website.Home.Business.Models
{
    public class OrderDto
    {
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
    }
}
