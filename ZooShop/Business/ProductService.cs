using System.Collections.Generic;
using ZooShop.Business.Interfaces;
using ZooShop.Data.Entities;
using ZooShop.Data.UnitOfWork;


namespace ZooShop.Business.Services
{
    public class ProductService : IProductService
    {

        private UnitOfWork _unitOfWork;

        public ProductService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Product product)
        {
            _unitOfWork.Products.Create(product);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Products.Delete(id);
            _unitOfWork.Save();
        }

        public Product Get(int id)
        {
            return _unitOfWork.Products.Get(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _unitOfWork.Products.GetAll();
        }

        public void Update(Product product)
        {
            _unitOfWork.Products.Update(product);
            _unitOfWork.Save();
        }
    }
}
