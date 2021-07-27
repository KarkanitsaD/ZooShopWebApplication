using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooShop.Website.Home.Data.Query
{
    public class QueryParameters<T> where T: class
    {
        public FilterRule<T> FilterRule { get; set; }

        public SortRule<T> SortRule { get; set; }

    }
}
