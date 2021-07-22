using System.Collections.Generic;
using System.Linq;
using ZooShop.Website.Home.Data.Contracts;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Data
{
    public class CategoryRepository : IRepository<CategoryEntity>
    {
        public CategoryRepository(ZooShopContext db)
        {
            _context = db;
        }

        private readonly ZooShopContext _context;

        public void Create(CategoryEntity item)
        {
            _context.Categories.Add(item);
        }

        public void Delete(int id)
        {
            _context.Categories.Remove(_context.Categories.First(c => c.Id == id));
        }

        public CategoryEntity Get(int id)
        {
            return _context.Categories.First(c => c.Id == id);
        }

        public IEnumerable<CategoryEntity> GetAll()
        {
            return _context.Categories.ToList();
        }

        public void Update(CategoryEntity item)
        {
            _context.Categories.Update(item);
        }
    }
}
