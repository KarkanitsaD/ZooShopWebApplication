using System.Collections.Generic;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Business.Contracts
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
