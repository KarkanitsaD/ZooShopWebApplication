using System.Collections.Generic;
using System.Threading.Tasks;
using ZooShop.Website.Home.Data.Query;

namespace ZooShop.Website.Home.Data.Contracts
{
    public interface ITestRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        IEnumerable<TEntity> GetAll(QueryParameters<TEntity> queryParameters = null);
        Task<IEnumerable<TEntity>> GetAllAsync(QueryParameters<TEntity> queryParameters = null);

        TEntity Get(TKey id);
        Task<TEntity> GetAsync(TKey id);

        void Create(TKey id);
        Task CreateAsync(TKey id);

        void CreateRange(List<TEntity> items);
        Task CreateRangeAsync(List<TEntity> items);

        void Update(TEntity item);
        Task UpdateAsync(TEntity item);

        void Delete(TEntity item);
        Task DeleteAsync(TEntity item);
    }
}
