﻿using System.Collections.Generic;
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
            _unitOfWork.GetRepository<ProductEntity>().Create(product);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<ProductEntity>().Delete(id);
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
    }
}
