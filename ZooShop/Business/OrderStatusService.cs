using System.Collections.Generic;
using ZooShop.Business.Interfaces;
using ZooShop.Data.Entities;
using ZooShop.Data.UnitOfWork;

namespace ZooShop.Business.Services
{
    public class OrderStatusService : IOrderStatusService
    {

        private UnitOfWork _unitOfWork;

        public OrderStatusService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(OrderStatus orderStatus)
        {
            _unitOfWork.OrderStatuses.Create(orderStatus);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.OrderStatuses.Delete(id);
            _unitOfWork.Save();
        }

        public OrderStatus Get(int id)
        {
            return _unitOfWork.OrderStatuses.Get(id);
        }

        public IEnumerable<OrderStatus> GetAll()
        {
            return _unitOfWork.OrderStatuses.GetAll();
        }

        public void Update(OrderStatus orderStatus)
        {
            _unitOfWork.OrderStatuses.Update(orderStatus);
            _unitOfWork.Save();
        }
    }
}
