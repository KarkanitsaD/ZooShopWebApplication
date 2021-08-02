using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task CreateAsync(T item)
        {
            await _table.AddAsync(item);
        }

        public void CreateRange(List<T> items)
        {
            foreach (var item in items)
            {
                _table.Add(item);
            }
        }
        public async Task CreateRangeAsync(List<T> items)
        {
            foreach (var item in items)
            {
                //await Task.Run(()=>_table.Add(item));
                await _table.AddAsync(item);
            }
        }

        public void Delete(T item)
        {
            _table.Remove(item);
        }
        public async Task DeleteAsync(T item)
        {
            await Task.Run(() => _table.Remove(item));
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
        public async Task UpdateAsync(T item)
        {
            await Task.Run(() => _context.Entry(item).State = EntityState.Modified);
        }

        public T Get(int id)
        {
            T item = _table.Find(id);
            if (item == null)
                item = new T();
            return item;
        }
        public async Task<T> GetAsync(int id)
        {
            T item = await _table.FindAsync(id);
            if (item == null)
                item = new T();
            return item;
        }

        public IEnumerable<T> GetAll(QueryParameters<T> queryParameters = null)
        {
            var query = GetQuery(queryParameters);

            return query.AsEnumerable();
        }
        public async Task<IEnumerable<T>> GetAllAsync(QueryParameters<T> queryParameters = null)
        {
            return await Task.Run(()=>GetQuery(queryParameters).AsEnumerable());
        }

        private IEnumerable<T> GetQuery(QueryParameters<T> queryParameters = null)
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
