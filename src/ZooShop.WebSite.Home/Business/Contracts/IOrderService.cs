using System.Collections.Generic;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Business.Contracts
{
    public interface IOrderService
    {
        void Create(OrderEntity order);
        void Update(OrderEntity order);
        void Delete(int id);
        OrderEntity Get(int id);
        IEnumerable<OrderEntity> GetAll();
        IEnumerable<OrderEntity> Get( int? userId, int? statusId, string firstname, string surname, string lastname,
            string email, string phone, string country, string city, string street, string house, string flat);
    }
}
