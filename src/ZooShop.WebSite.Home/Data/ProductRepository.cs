using System.Collections.Generic;
using System.Linq;
using ZooShop.Website.Home.Data.Contracts;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Data
{
    public class ProductRepository : IRepository<ProductEntity>
    {

        public ProductRepository(ZooShopContext db)
        {
            _context = db;
        }

        private readonly ZooShopContext _context;

        public void Create(ProductEntity item)
        {
            _context.Products.Add(item);
        }

        public void Delete(int id)
        {
            _context.Products.Remove(_context.Products.First(p => p.Id == id));
        }

        public ProductEntity Get(int id)
        {
            return _context.Products.First(p => p.Id == id);
        }

        public IEnumerable<ProductEntity> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Update(ProductEntity item)
        {
            _context.Products.Update(item);
        }
    }
}
