namespace ZooShop.Website.Home.Data.Contracts
{
    public interface IUnitOfWork
    {
        void Save();
        Repository<T> GetRepository<T>() where T : class, new();
    }
}
