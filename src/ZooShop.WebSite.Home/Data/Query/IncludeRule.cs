using System;
using System.Linq.Expressions;

namespace ZooShop.Website.Home.Data.Query
{
    public class IncludeRule<T> where T: class
    {
        public Expression<Func<T, object>> Expression { get; set; }
    }
}
