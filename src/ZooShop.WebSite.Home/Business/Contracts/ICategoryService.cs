using System.Collections.Generic;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Business.Contracts
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
