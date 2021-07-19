using System.Collections.Generic;
using ZooShop.Business.Contracts;
using ZooShop.Data.Entities;
using ZooShop.Data;

namespace ZooShop.Business.Services
{
    public class OrderService : IOrderService
    {

        private UnitOfWork _unitOfWork;


        public OrderService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(OrderEntity order)
        {
            _unitOfWork.Orders.Create(order);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Orders.Delete(id);
            _unitOfWork.Save();
        }

        public OrderEntity Get(int id)
        {
            return _unitOfWork.Orders.Get(id);
        }

        public IEnumerable<OrderEntity> GetAll()
        {
            return _unitOfWork.Orders.GetAll();
        }

        public void Update(OrderEntity order)
        {
            _unitOfWork.Orders.Update(order);
            _unitOfWork.Save();
        }
    }
}
