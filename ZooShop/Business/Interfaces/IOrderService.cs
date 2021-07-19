using System.Collections.Generic;
using ZooShop.Data.Entities;

namespace ZooShop.Business.Interfaces
{
    public interface IOrderService
    {
        void Create(Order order);
        void Update(Order order);
        void Delete(int id);
        Order Get(int id);
        IEnumerable<Order> GetAll();
    }
}
