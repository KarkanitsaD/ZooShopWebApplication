using System.Collections.Generic;
using System.Linq;
using ZooShop.Data.Entities;
using ZooShop.Data.Interfaces;

namespace ZooShop.Data.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        public CategoryRepository(ZooShopContext db)
        {
            _context = db;
        }

        private ZooShopContext _context;

        public void Create(Category item)
        {
            _context.Categories.Add(item);
        }

        public void Delete(int id)
        {
            _context.Categories.Remove(_context.Categories.First(c => c.Id == id));
        }

        public Category Get(int id)
        {
            return _context.Categories.First(c => c.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public void Update(Category item)
        {
            _context.Categories.Update(item);
        }
    }
}
