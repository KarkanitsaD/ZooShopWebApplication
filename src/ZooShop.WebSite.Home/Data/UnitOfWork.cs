using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZooShop.Website.Home.Data.Contracts;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Data
{
    public class UnitOfWork
    {
        private readonly ZooShopContext _context;
        private readonly Dictionary<string, object> _repositories; 

        public UnitOfWork(ZooShopContext context)
        {
            _context = context;
            _repositories = new Dictionary<string, object>();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public GenericRepository<T> GetRepository<T>() where T : class
        {

            string key = typeof(T).ToString();
            if (!_repositories.ContainsKey(key))
            {
                var repository = new GenericRepository<T>(_context);
                _repositories.Add(key, repository);
            }

            return (GenericRepository<T>)_repositories[key];
        }
    }
}
