using AutoMapper;
using System.Collections.Generic;
using ZooShop.Business.Contracts;
using ZooShop.Data.Entities;
using ZooShop.Data;
using ZooShop.Business.DTOs;

namespace ZooShop.Business.Services
{
    public class UserService : IUserService
    {
        private UnitOfWork _unitOfWork;

        public UserService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }        

        public void Create(UserEntity user)
        {
            _unitOfWork.Users.Create(user);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Users.Delete(id);
            _unitOfWork.Save();
        }

        public UserEntity Get(int id)
        {
            return _unitOfWork.Users.Get(id);
        }

        public IEnumerable<UserDto> GetAll()
        {
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<UserEntity, UserDto>()
                    .ForMember("FullName", opt => opt.MapFrom(u => u.FirstName + " " + u.LastName + " " + u.Surname))
                    .ForMember("Id", opt => opt.MapFrom(u => u.Id))
                    .ForMember("Email", opt => opt.MapFrom(u => u.Email))
                );

            var mapper = new Mapper(config);

            var users = mapper.Map<IEnumerable<UserEntity>, List<UserDto>>(_unitOfWork.Users.GetAll());
            return users;
        }

        public void Update(UserEntity user)
        {
            _unitOfWork.Users.Update(user);
            _unitOfWork.Save();
        }

        //public void AddItemToCart(int userId, CartItem cartItem)
        //{
        //    var user = _unitOfWork.Users.Get(userId);
        //    user.Cart.CartItems.Add(cartItem);
        //    _unitOfWork.Users.Update(user);
        //    _unitOfWork.Save();
        //}
    }
}
