using System.Collections.Generic;
using ZooShop.Data.Entities;

namespace ZooShop.Business.Contracts
{
    public interface IOrderService
    {
        void Create(OrderEntity order);
        void Update(OrderEntity order);
        void Delete(int id);
        OrderEntity Get(int id);
        IEnumerable<OrderEntity> GetAll();
    }
}
