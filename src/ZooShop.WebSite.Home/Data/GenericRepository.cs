using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZooShop.Website.Home.Data.Contracts;

namespace ZooShop.Website.Home.Data
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        public GenericRepository(DbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        private DbContext _context;
        private DbSet<T> _table;


        public void Create(T item)
        {
            _table.Add(item);
        }

        public void Delete(T item)
        {
            _table.Remove(item);
        }

        public T Get(int id)
        {
            return _table.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public void Update(T item)
        {
            _table.Update(item);
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return _table.Where(predicate).ToList();
        }
    }
}
