using System.Collections.Generic;
using ZooShop.Website.Home.Business.Models;
using ZooShop.Website.Home.Data.Entities;


namespace ZooShop.Website.Home.Business.Contracts
{
    public interface IUserService
    {
        void Create(UserEntity user);
        void Update(UserEntity user);
        void Delete(int id);
        UserDto Get(int id);
        IEnumerable<UserDto> GetAll();
    }
}
