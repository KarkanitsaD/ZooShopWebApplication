using System.Collections.Generic;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Data;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Business
{
    public class OrderService : IOrderService
    {

        private readonly UnitOfWork _unitOfWork;


        public OrderService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(OrderEntity order)
        {
            _unitOfWork.GetRepository<OrderEntity>().Create(order);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<OrderEntity>().Delete(id);
            _unitOfWork.Save();
        }

        public OrderEntity Get(int id)
        {
            return _unitOfWork.GetRepository<OrderEntity>().Get(id);
        }

        public IEnumerable<OrderEntity> GetAll()
        {
            return _unitOfWork.GetRepository<OrderEntity>().GetAll();
        }

        public void Update(OrderEntity order)
        {
            _unitOfWork.GetRepository<OrderEntity>().Update(order);
            _unitOfWork.Save();
        }
    }
}
