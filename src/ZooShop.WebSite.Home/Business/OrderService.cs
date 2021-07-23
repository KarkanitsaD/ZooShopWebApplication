using System;
using System.Collections.Generic;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Data.Contracts;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Business
{
    public class OrderService : IOrderService
    {

        private readonly IUnitOfWork _unitOfWork;


        public OrderService(IUnitOfWork unitOfWork)
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
            var repository = _unitOfWork.GetRepository<OrderEntity>();
            var order = repository.Get(id);
            if (order == null)
            {
                throw new Exception("test exception");
            }
            repository.Delete(order);
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
