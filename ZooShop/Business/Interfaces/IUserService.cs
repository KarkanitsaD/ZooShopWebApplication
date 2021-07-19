using System.Collections.Generic;
using ZooShop.Business.DTOs;
using ZooShop.Data.Entities;


namespace ZooShop.Business.Interfaces
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
