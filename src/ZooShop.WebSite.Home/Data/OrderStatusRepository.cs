using System.Collections.Generic;
using System.Linq;
using ZooShop.Data.Entities;
using ZooShop.Data.Contracts;

namespace ZooShop.Data
{
    public class OrderStatusRepository : IRepository<OrderStatusEntity>
    {

        public OrderStatusRepository(ZooShopContext db)
        {
            _context = db;
        }

        private ZooShopContext _context;

        public void Create(OrderStatusEntity item)
        {
            _context.OrderStatuses.Add(item);
        }

        public void Delete(int id)
        {
            _context.OrderStatuses.Remove(_context.OrderStatuses.First(os => os.Id == id));
        }

        public OrderStatusEntity Get(int id)
        {
            return _context.OrderStatuses.First(os => os.Id == id);
        }

        public IEnumerable<OrderStatusEntity> GetAll()
        {
            return _context.OrderStatuses.ToList();
        }

        public void Update(OrderStatusEntity item)
        {
            _context.OrderStatuses.Update(item);
        }
    }
}
