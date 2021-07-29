using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.XPath;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Data.Contracts;
using ZooShop.Website.Home.Data.Entities;
using ZooShop.Website.Home.Data.Query;

namespace ZooShop.Website.Home.Business
{
    public class ProductService : IProductService
    {

        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(ProductEntity product)
        {
            _unitOfWork.GetRepository<ProductEntity>().Create(product);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var repository = _unitOfWork.GetRepository<ProductEntity>();
            var product = repository.Get(id);
            repository.Delete(product);
            _unitOfWork.Save();
        }

        public ProductEntity Get(int id)
        {
            return _unitOfWork.GetRepository<ProductEntity>().Get(id);
        }

        public IEnumerable<ProductEntity> GetAll()
        {
            return _unitOfWork.GetRepository<ProductEntity>().GetAll();
        }

        public void Update(ProductEntity product)
        {
            _unitOfWork.GetRepository<ProductEntity>().Update(product);
            _unitOfWork.Save();
        }


        public IEnumerable<ProductEntity> GetWithFilter(string title)
        {
            Expression<Func<ProductEntity, bool>> filterExpression = x =>
                x.Title.Contains(title);

            Expression<Func<ProductEntity, object>> sortExpression = x =>
                x.Price;

            Expression<Func<ProductEntity, object>> includeExpression = x =>
                x.Categories;

            QueryParameters<ProductEntity> queryParameters = new QueryParameters<ProductEntity>()
            {
                FilterRule = new FilterRule<ProductEntity>()
                {
                    Expression = filterExpression
                },
                SortRule = new SortRule<ProductEntity>()
                {
                    Order = SortOrder.Ascending,
                    Expression = sortExpression
                },
                IncludeRule = new IncludeRule<ProductEntity>()
                {
                    //Expression = includeExpression
                }
            };

            return _unitOfWork.GetRepository<ProductEntity>().Get(queryParameters);  
        }
    }
}
