using System;
using System.Linq.Expressions;

namespace ZooShop.Website.Home.Data.Query
{
    public class FilterRule<T> where T: class
    {
        public Expression<Func<T, bool>> Expression { get; set; }
    }
}
