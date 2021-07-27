﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ZooShop.Website.Home.Data.Contracts;

namespace ZooShop.Website.Home.Data
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {

        public Repository(DbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        private readonly DbContext _context;
        private readonly DbSet<T> _table;


        public void Create(T item)
        {
            _table.Add(item);
        }

        public void Delete(T item)
        {
            _table.Remove(item);
        }

        public T Get(int id)
        {
            T item = _table.Find(id);
            if (item == null)
                item = new T();
            return item;
        }

        public IEnumerable<T> GetAll()
        {
            return _table.AsNoTracking();
        }

        public void Update(T item)
        {
            _table.Update(item);
        }

        public IEnumerable<T> Get(Func<T, bool> filterPredicate, Func<T, object> sortPredicate)
        {
            return _table.AsNoTracking().AsEnumerable().Where(filterPredicate).OrderBy(sortPredicate);
        }

        public void CreateRange(List<T> items)
        {
            foreach (var item in items)
            {
                _table.Add(item);
            }
        }
    }
}
