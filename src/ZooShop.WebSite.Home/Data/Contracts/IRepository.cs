using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ZooShop.Website.Home.Data.Query;

namespace ZooShop.Website.Home.Data.Contracts
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(QueryParameters<T> queryParameters = null);
        T Get(int id);
        void Create(T item);
        void CreateRange(List<T> items);
        void Update(T item);
        void Delete(T item);
         
    }
}
