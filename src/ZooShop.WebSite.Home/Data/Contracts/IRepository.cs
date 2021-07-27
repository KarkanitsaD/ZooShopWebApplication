using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ZooShop.Website.Home.Data.Contracts
{
    public interface IRepository<T> where T : class
    {        
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Func<T, bool> filterPredicate, Func<T, object> sortPredicate);
        T Get(int id);
        void Create(T item);
        void CreateRange(List<T> items);
        void Update(T item);
        void Delete(T item);
         
    }
}
