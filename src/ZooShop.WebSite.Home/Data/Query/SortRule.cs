using System;
using System.Linq.Expressions;

namespace ZooShop.Website.Home.Data.Query
{
    public class SortRule<T> where T: class
    {
        public Func<T, object> Expression { get; set; }

        public SortOrder Order { get; set; }
    }
}
