using System.Collections.Generic;
using ZooShop.Data.Entities;

namespace ZooShop.Business.Interfaces
{
    public interface IProductService
    {
        void Create(Product product);
        void Update(Product product);
        void Delete(int id);
        Product Get(int id);
        IEnumerable<Product> GetAll();
    }
}
