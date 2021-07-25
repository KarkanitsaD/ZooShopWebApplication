namespace ZooShop.Website.Home.Data.Contracts
{
    public interface IUnitOfWork
    {
        void Save();
        IRepository<T> GetRepository<T>() where T : class, new();
    }
}
