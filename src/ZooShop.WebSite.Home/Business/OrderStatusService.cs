using System.Collections.Generic;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Data;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Business
{
    public class OrderStatusService : IOrderStatusService
    {

        private readonly UnitOfWork _unitOfWork;

        public OrderStatusService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(OrderStatusEntity orderStatus)
        {
            _unitOfWork.OrderStatuses.Create(orderStatus);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.OrderStatuses.Delete(id);
            _unitOfWork.Save();
        }

        public OrderStatusEntity Get(int id)
        {
            return _unitOfWork.OrderStatuses.Get(id);
        }

        public IEnumerable<OrderStatusEntity> GetAll()
        {
            return _unitOfWork.OrderStatuses.GetAll();
        }

        public void Update(OrderStatusEntity orderStatus)
        {
            _unitOfWork.OrderStatuses.Update(orderStatus);
            _unitOfWork.Save();
        }
    }
}
