
using Microsoft.AspNetCore.Mvc;

namespace ZooShop.Website.Home.Business.QueryModels
{
    public class OrderQueryModel : BaseQueryModel
    {
        [FromQuery(Name = "UserId")]
        public int? UserId { get; set; }

        [FromQuery(Name = "StatusId")]
        public int? StatusId { get; set; }

        [FromQuery(Name = "Phone")]
        public string Phone { get; set; }

        [FromQuery(Name = "Email")]
        public string Email { get; set; }

        public override bool IsValidToFilter()
        {
            if (UserId == null && StatusId == null && Phone == null && Email == null && !base.IsValidToFilter())
                return false;
            return true;
        }
    }
}
