using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZooShop.Website.Home.Data.Contracts;
using ZooShop.Website.Home.Data.Query;

namespace ZooShop.Website.Home.Data
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _table;

        public Repository(DbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public void Create(T item)
        {
            _table.Add(item);
        }

        public void CreateRange(List<T> items)
        {
            foreach (var item in items)
            {
                _table.Add(item);
            }
        }

        public void Delete(T item)
        {
            _table.Remove(item);
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public T Get(int id)
        {
            T item = _table.Find(id);
            if (item == null)
                item = new T();
            return item;
        }

        public IEnumerable<T> GetAll(QueryParameters<T> queryParameters = null)
        {
            var query = _table.AsNoTracking().AsEnumerable();
            if (queryParameters == null)
                return query;

            if (queryParameters.FilterRule != null && queryParameters.FilterRule.Expression != null)
                query = query.Where(queryParameters.FilterRule.Expression.Compile());

            if (queryParameters.SortRule != null && queryParameters.SortRule.Expression != null)
            {
                if (queryParameters.SortRule.Order == SortOrder.Ascending)
                    query = query.OrderBy(queryParameters.SortRule.Expression.Compile());
                else
                    query = query.OrderByDescending(queryParameters.SortRule.Expression.Compile());
            }

            return query;
        }
    }
}
