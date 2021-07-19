using System.Collections.Generic;
using ZooShop.Data.Entities;

namespace ZooShop.Business.Contracts
{
    public interface IProductService
    {
        void Create(ProductEntity product);
        void Update(ProductEntity product);
        void Delete(int id);
        ProductEntity Get(int id);
        IEnumerable<ProductEntity> GetAll();
    }
}
