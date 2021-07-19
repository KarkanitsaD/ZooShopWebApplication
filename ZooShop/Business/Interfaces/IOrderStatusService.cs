using System.Collections.Generic;
using ZooShop.Data.Entities;

namespace ZooShop.Business.Interfaces
{
    public interface IOrderStatusService
    {
        void Create(OrderStatus orderStatus);
        void Update(OrderStatus orderStatus);
        void Delete(int id);
        OrderStatus Get(int id);
        IEnumerable<OrderStatus> GetAll();
    }
}
