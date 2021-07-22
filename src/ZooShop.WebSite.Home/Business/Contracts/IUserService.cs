using System.Collections.Generic;
using ZooShop.Website.Home.Business.DTOs;
using ZooShop.Website.Home.Data.Entities;


namespace ZooShop.Website.Home.Business.Contracts
{
    public interface IUserService
    {
        void Create(UserEntity user);
        void Update(UserEntity user);
        void Delete(int id);
        UserEntity Get(int id);
        //void AddItemToCart(int userId, CartItem cartItem);
        IEnumerable<UserDto> GetAll();
    }
}
