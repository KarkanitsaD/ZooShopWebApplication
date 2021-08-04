
using Microsoft.AspNetCore.Mvc;

namespace ZooShop.Website.Home.Business.QueryModels
{
    public class UserQueryModel : BaseQueryModel
    {
        [FromQuery(Name = "FirstName")] 
        public string FirstName { get; set; } = null;

        [FromQuery(Name = "Surname")] 
        public string Surname { get; set; } = null;

        [FromQuery(Name = "LastName")]
        public string LastName { get; set; } = null;

        [FromQuery(Name = "Email")]
        public string Email { get; set; } = null;

        public override bool IsValidToFilter()
        {
            if (FirstName == null && Surname == null && LastName == null && Email == null && !base.IsValidToFilter())
                return false;
            return true;
        }
    }
}
