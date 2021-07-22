using System.Collections.Generic;
using System.Linq;
using ZooShop.Website.Home.Data.Contracts;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Data
{
    public class OrderRepository : IRepository<OrderEntity>
    {

        public OrderRepository(ZooShopContext db)
        {
            _context = db;
        }

        private readonly ZooShopContext _context;

        public void Create(OrderEntity item)
        {
            _context.Orders.Add(item);
        }

        public void Delete(int id)
        {
            _context.Orders.Remove(_context.Orders.First(o => o.Id == id));
        }

        public OrderEntity Get(int id)
        {
            return _context.Orders.First(o => o.Id == id);
        }

        public IEnumerable<OrderEntity> GetAll()
        {
            return new List<OrderEntity>(_context.Orders.ToList());
        }

        public void Update(OrderEntity item)
        {
            _context.Orders.Update(item);
        }
    }
}
