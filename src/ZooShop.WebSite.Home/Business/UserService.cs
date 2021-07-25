using System;
using System.Collections.Generic;
using AutoMapper;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Business.Models;
using ZooShop.Website.Home.Data.Contracts;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Business
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }        

        public void Create(UserEntity user)
        {
            _unitOfWork.GetRepository<UserEntity>().Create(user);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var repository = _unitOfWork.GetRepository<UserEntity>();
            var user = repository.Get(id);
            repository.Delete(user);
            _unitOfWork.Save();
        }

        public UserDto Get(int id)
        {
            return GetMapper().Map<UserEntity, UserDto>(_unitOfWork.GetRepository<UserEntity>().Get(id));
        }

        public IEnumerable<UserDto> GetAll()
        {
            var users = GetMapper().Map<IEnumerable<UserEntity>, List<UserDto>>(_unitOfWork.GetRepository<UserEntity>().GetAll());
            return users;
        }

        public void Update(UserEntity user)
        {
            _unitOfWork.GetRepository<UserEntity>().Update(user);
            _unitOfWork.Save();
        }

        private static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<UserEntity, UserDto>()
                    .ForMember("FullName", opt => opt.MapFrom(u => u.FirstName + " " + u.LastName + " " + u.Surname))
                    .ForMember("Id", opt => opt.MapFrom(u => u.Id))
                    .ForMember("Email", opt => opt.MapFrom(u => u.Email))
            );

            var mapper = new Mapper(config);
            return mapper;
        }
        
    }
}
