using System.Collections.Generic;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Data;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Business
{
    public class ProductService : IProductService
    {

        private readonly UnitOfWork _unitOfWork;

        public ProductService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(ProductEntity product)
        {
            _unitOfWork.Products.Create(product);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Products.Delete(id);
            _unitOfWork.Save();
        }

        public ProductEntity Get(int id)
        {
            return _unitOfWork.Products.Get(id);
        }

        public IEnumerable<ProductEntity> GetAll()
        {
            return _unitOfWork.Products.GetAll();
        }

        public void Update(ProductEntity product)
        {
            _unitOfWork.Products.Update(product);
            _unitOfWork.Save();
        }
    }
}
