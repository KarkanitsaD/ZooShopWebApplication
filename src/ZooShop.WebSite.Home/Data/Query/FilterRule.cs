using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ZooShop.Website.Home.Data.Query
{
    public class FilterRule<T> where T: class, new()
    {
        public Expression<Func<T, bool>> Expression { get; set; }
    }
}
