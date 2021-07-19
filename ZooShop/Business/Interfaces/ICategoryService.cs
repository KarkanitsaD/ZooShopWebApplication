using System.Collections.Generic;
using ZooShop.Data.Entities;

namespace ZooShop.Business.Interfaces
{
    public interface ICategoryService
    {
        void Create(Category category);
        void Update(Category category);
        void Delete(int id);
        Category Get(int id);
        IEnumerable<Category> GetAll();
    }
}
