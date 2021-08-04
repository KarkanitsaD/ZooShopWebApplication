using System.Collections.Generic;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Business.Contracts
{
    public interface IProductService
    {
        void Create(ProductEntity product);
        void Update(ProductEntity product);
        void Delete(int id);
        ProductEntity Get(int id);
        IEnumerable<ProductEntity> GetAll();
        IEnumerable<ProductEntity> GetWithFilter(string title);
    }
}
