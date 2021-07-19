using System.Collections.Generic;
using System.Linq;
using ZooShop.Data.Entities;
using ZooShop.Data.Interfaces;

namespace ZooShop.Data.Repositories
{
    public class ProductRepository : IRepository<Product>
    {

        public ProductRepository(ZooShopContext db)
        {
            _context = db;
        }

        private ZooShopContext _context;

        public void Create(Product item)
        {
            _context.Products.Add(item);
        }

        public void Delete(int id)
        {
            _context.Products.Remove(_context.Products.First(p => p.Id == id));
        }

        public Product Get(int id)
        {
            return _context.Products.First(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Update(Product item)
        {
            _context.Products.Update(item);
        }
    }
}
