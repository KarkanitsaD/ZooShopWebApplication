using System.Collections.Generic;
using ZooShop.Business.Interfaces;
using ZooShop.Data.Entities;
using ZooShop.Data.UnitOfWork;

namespace ZooShop.Business.Services
{
    public class OrderService : IOrderService
    {

        private UnitOfWork _unitOfWork;


        public OrderService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Order order)
        {
            _unitOfWork.Orders.Create(order);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Orders.Delete(id);
            _unitOfWork.Save();
        }

        public Order Get(int id)
        {
            return _unitOfWork.Orders.Get(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _unitOfWork.Orders.GetAll();
        }

        public void Update(Order order)
        {
            _unitOfWork.Orders.Update(order);
            _unitOfWork.Save();
        }
    }
}
