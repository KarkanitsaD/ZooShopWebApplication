using System.Collections.Generic;
using ZooShop.Website.Home.Data.Contracts;


namespace ZooShop.Website.Home.Data
{
    public class UnitOfWork: IUnitOfWork
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

        public Repository<T> GetRepository<T>() where T : class, new()
        {
            string key = typeof(T).ToString();
            if (!_repositories.ContainsKey(key))
            {
                var repository = new Repository<T>(_context);
                _repositories.Add(key, repository);
            }

            return (Repository<T>)_repositories[key];
        }
    }
}
