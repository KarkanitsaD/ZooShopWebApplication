using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZooShop.Website.Home.Data.Query;

namespace ZooShop.Website.Home.Data.Contracts
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(QueryParameters<T> queryParameters = null);
        Task<IEnumerable<T>> GetAllAsync(QueryParameters<T> queryParameters = null);

        T Get(int id);
        Task<T> GetAsync(int id);

        void Create(T item);
        Task CreateAsync(T item);

        void CreateRange(List<T> items);
        Task CreateRangeAsync(List<T> items);

        void Update(T item);
        Task UpdateAsync(T item);

        void Delete(T item);
        Task DeleteAsync(T item);

    }
}
