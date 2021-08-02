using System.Threading.Tasks;

namespace ZooShop.Website.Home.Data.Contracts
{
    public interface IUnitOfWork
    {
        int Save();
        Task<int> SaveAsync();
        IRepository<T> GetRepository<T>() where T : class, new();
    }
}
