using System.Collections.Generic;
using System.Linq;
using ZooShop.Data.Entities;
using ZooShop.Data.Contracts;

namespace ZooShop.Data
{
    public class UserRepository : IRepository<UserEntity>
    {
        public UserRepository(ZooShopContext db)
        {
            _context = db;
        }

        private ZooShopContext _context;


        public void Create(UserEntity item)
        {
            _context.Users.Add(item);
        }

        public void Delete(int id)
        {
            _context.Users.Remove(_context.Users.First(u => u.Id == id));
        }

        public UserEntity Get(int id)
        {
            return _context.Users.First(u => u.Id == id);
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Update(UserEntity item)
        {
            _context.Users.Update(item);
        }
    }
}
