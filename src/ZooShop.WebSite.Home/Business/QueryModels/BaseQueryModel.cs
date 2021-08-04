using Microsoft.AspNetCore.Mvc;
using ZooShop.Website.Home.Data.Query;

namespace ZooShop.Website.Home.Business.QueryModels
{
    public abstract class BaseQueryModel
    {
        [FromQuery(Name = "SortOrder")]
        public SortOrder? SortOrder { get; set; } = null;

        [FromQuery(Name = "IsStrictFiltration")]
        public bool? IsStrictFiltration { get; set; } = null;

        public virtual bool IsValidToFilter()
        {
            if (SortOrder == null)
                return false;
            return true;
        }
    }
}
