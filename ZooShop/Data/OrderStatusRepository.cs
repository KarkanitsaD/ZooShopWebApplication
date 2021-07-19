using System.Collections.Generic;
using System.Linq;
using ZooShop.Data.Entities;
using ZooShop.Data.Interfaces;

namespace ZooShop.Data.Repositories
{
    public class OrderStatusRepository : IRepository<OrderStatus>
    {

        public OrderStatusRepository(ZooShopContext db)
        {
            _context = db;
        }

        private ZooShopContext _context;

        public void Create(OrderStatus item)
        {
            _context.OrderStatuses.Add(item);
        }

        public void Delete(int id)
        {
            _context.OrderStatuses.Remove(_context.OrderStatuses.First(os => os.Id == id));
        }

        public OrderStatus Get(int id)
        {
            return _context.OrderStatuses.First(os => os.Id == id);
        }

        public IEnumerable<OrderStatus> GetAll()
        {
            return _context.OrderStatuses.ToList();
        }

        public void Update(OrderStatus item)
        {
            _context.OrderStatuses.Update(item);
        }
    }
}
