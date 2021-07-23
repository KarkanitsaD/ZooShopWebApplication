using System.Collections.Generic;
using AutoMapper;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Business.DTOs;
using ZooShop.Website.Home.Data;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Business
{
    public class UserService : IUserService
    {
        private readonly UnitOfWork _unitOfWork;

        public UserService(UnitOfWork unitOfWork)
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

        public UserEntity Get(int id)
        {
            return _unitOfWork.GetRepository<UserEntity>().Get(id);
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

            var users = mapper.Map<IEnumerable<UserEntity>, List<UserDto>>(_unitOfWork.GetRepository<UserEntity>().GetAll());
            return users;
        }

        public void Update(UserEntity user)
        {
            _unitOfWork.GetRepository<UserEntity>().Update(user);
            _unitOfWork.Save();
        }

        
    }
}
