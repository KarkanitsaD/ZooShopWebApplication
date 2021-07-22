using System.Collections.Generic;
using System.Linq;
using ZooShop.Website.Home.Data.Contracts;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Data
{
    public class UserRepository : IRepository<UserEntity>
    {
        public UserRepository(ZooShopContext db)
        {
            _context = db;
        }

        private readonly ZooShopContext _context;


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
