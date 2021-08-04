using Microsoft.AspNetCore.Mvc;

namespace ZooShop.Website.Home.Business.QueryModels
{
    public class ProductQueryModel : BaseQueryModel
    {
        [FromQuery(Name = "Title")]
        public string Title { get; set; }

        [FromQuery(Name = "MaxPrice")]
        public float? MaxPrice { get; set; }

        [FromQuery(Name = "MinPrice")]
        public float? MinPrice { get; set; }

        public override bool IsValidToFilter()
        {
            if (Title == null && MaxPrice == null && MinPrice == null && !base.IsValidToFilter())
                return false;
            return true;
        }
    }
}
