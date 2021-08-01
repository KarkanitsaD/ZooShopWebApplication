using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Data.Contracts;
using ZooShop.Website.Home.Data.Entities;
using ZooShop.Website.Home.Data.Query;

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

        public IEnumerable<OrderEntity> Get(int? userId, int? statusId, string firstname, string surname, string lastname,
            string email, string phone, string country, string city, string street, string house, string flat)
        {
            Func<OrderEntity, bool> filterPredicate = delegate(OrderEntity order)
            {
                if (userId != null)
                {
                    if (order.Id != userId)
                        return false;
                }
                if (statusId != null)
                {
                    if (order.StatusId != statusId)
                        return false;
                }
                if (!string.IsNullOrEmpty(firstname))
                {
                    if (!order.FirstName.Contains(firstname))
                        return false;
                }
                if (!string.IsNullOrEmpty(surname))
                {
                    if (!order.Surname.Contains(surname))
                        return false;
                }
                if (!string.IsNullOrEmpty(lastname))
                {
                    if (!order.LastName.Contains(lastname))
                        return false;
                }
                if (!string.IsNullOrEmpty(email))
                {
                    if (!order.Email.Equals(email))
                        return false;
                }
                if (!string.IsNullOrEmpty(phone))
                {
                    if (!order.Phone.Equals(phone))
                        return false;
                }
                if (!string.IsNullOrEmpty(country))
                {
                    if (!order.Country.Contains(country))
                        return false;
                }
                if (!string.IsNullOrEmpty(city))
                {
                    if (!order.City.Contains(city))
                        return false;
                }
                if (!string.IsNullOrEmpty(street))
                {
                    if (!order.Street.Contains(street))
                        return false;
                }
                if (!string.IsNullOrEmpty(house))
                {
                    if (!order.House.Equals(house))
                        return false;
                }
                if (!string.IsNullOrEmpty(flat))
                {
                    if (!order.Flat.Equals(flat))
                        return false;
                }

                return true;
            };

            Expression<Func<OrderEntity, bool>> filterExpression = Expression.Lambda<Func<OrderEntity, bool>>(Expression.Call(filterPredicate.Method));

            Expression<Func<OrderEntity, object>> sortExpression = x => x.Id;

            Expression<Func<OrderEntity, object>> includExpression = x => x.Products;

            QueryParameters<OrderEntity> queryParameters = new QueryParameters<OrderEntity>()
            {
                FilterRule = new FilterRule<OrderEntity>()
                {
                    Expression = filterExpression
                },
                SortRule = new SortRule<OrderEntity>()
                {
                    Expression = sortExpression,
                    Order = SortOrder.Ascending
                }
            };

            return _unitOfWork.GetRepository<OrderEntity>().GetAll(queryParameters);
        }

        public void Update(OrderEntity order)
        {
            _unitOfWork.GetRepository<OrderEntity>().Update(order);
            _unitOfWork.Save();
        }
    }
}
