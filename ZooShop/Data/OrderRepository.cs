using System.Collections.Generic;
using System.Linq;
using ZooShop.Data.Entities;
using ZooShop.Data.Interfaces;
namespace ZooShop.Data.Repositories
{
    public class OrderRepository : IRepository<Order>
    {

        public OrderRepository(ZooShopContext db)
        {
            _context = db;
        }

        private ZooShopContext _context;

        public void Create(Order item)
        {
            _context.Orders.Add(item);
        }

        public void Delete(int id)
        {
            _context.Orders.Remove(_context.Orders.First(o => o.Id == id));
        }

        public Order Get(int id)
        {
            return _context.Orders.First(o => o.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return new List<Order>(_context.Orders.ToList());
        }

        public void Update(Order item)
        {
            _context.Orders.Update(item);
        }
    }
}
