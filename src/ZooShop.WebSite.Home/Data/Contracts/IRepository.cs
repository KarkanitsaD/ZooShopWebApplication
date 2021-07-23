using System;
using System.Collections.Generic;

namespace ZooShop.Website.Home.Data.Contracts
{
    public interface IRepository<T> where T : class
    {        
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Func<T, bool> predicate);
        T Get(int id);
        void Create(T item);
        void CreateRange(List<T> items);
        void Update(T item);
        void Delete(T item);
         
    }
}
