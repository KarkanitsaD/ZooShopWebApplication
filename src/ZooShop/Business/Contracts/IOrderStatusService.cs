using System.Collections.Generic;
using ZooShop.Data.Entities;

namespace ZooShop.Business.Contracts
{
    public interface IOrderStatusService
    {
        void Create(OrderStatusEntity orderStatus);
        void Update(OrderStatusEntity orderStatus);
        void Delete(int id);
        OrderStatusEntity Get(int id);
        IEnumerable<OrderStatusEntity> GetAll();
    }
}
