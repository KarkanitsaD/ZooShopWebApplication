using System;
using System.Collections.Generic;
using System.Linq;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Data.Contracts;
using ZooShop.Website.Home.Data.Entities;

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


        public IEnumerable<ProductEntity> GetWithFilter(string title, float? minPrice, float? maxPrice)
        {
            Func<ProductEntity, bool> filterPredicate = delegate(ProductEntity product)
            {
                if (!string.IsNullOrEmpty(title))
                {
                    if (!product.Title.Contains(title))
                        return false;
                }

                if ((float)product.Price < minPrice || (float)product.Price > maxPrice)
                    return false;
                return true;
            };

            Func<ProductEntity, object> sortPredicate = delegate (ProductEntity product)
            {
                return product.Price;
            };



            return _unitOfWork.GetRepository<ProductEntity>().Get(filterPredicate, sortPredicate);
        }
    }
}
