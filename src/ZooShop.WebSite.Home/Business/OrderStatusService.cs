using System.Collections.Generic;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Data;
using ZooShop.Website.Home.Data.Contracts;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Business
{
    public class OrderStatusService : IOrderStatusService
    {

        private readonly IUnitOfWork _unitOfWork;

        public OrderStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(OrderStatusEntity orderStatus)
        {
            _unitOfWork.GetRepository<OrderStatusEntity>().Create(orderStatus);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var repository = _unitOfWork.GetRepository<OrderStatusEntity>();
            var orderStatus = repository.Get(id);
            repository.Delete(orderStatus);
            _unitOfWork.Save();
        }

        public OrderStatusEntity Get(int id)
        {
            return _unitOfWork.GetRepository<OrderStatusEntity>().Get(id);
        }

        public IEnumerable<OrderStatusEntity> GetAll()
        {
            return _unitOfWork.GetRepository<OrderStatusEntity>().GetAll();
        }

        public void Update(OrderStatusEntity orderStatus)
        {
            _unitOfWork.GetRepository<OrderStatusEntity>().Update(orderStatus);
            _unitOfWork.Save();
        }
    }
}
