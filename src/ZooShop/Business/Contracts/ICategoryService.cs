using System.Collections.Generic;
using ZooShop.Data.Entities;

namespace ZooShop.Business.Contracts
{
    public interface ICategoryService
    {
        void Create(CategoryEntity category);
        void Update(CategoryEntity category);
        void Delete(int id);
        CategoryEntity Get(int id);
        IEnumerable<CategoryEntity> GetAll();
    }
}
