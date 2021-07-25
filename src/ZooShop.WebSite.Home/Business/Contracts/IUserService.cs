using System.Collections.Generic;
using ZooShop.Website.Home.Business.Models;
using ZooShop.Website.Home.Data.Entities;


namespace ZooShop.Website.Home.Business.Contracts
{
    public interface IUserService
    {
        void Create(UserDto user);
        void Update(UserDto user);
        void Delete(int id);
        UserEntity Get(int id);
        IEnumerable<UserDto> GetAll();
    }
}
