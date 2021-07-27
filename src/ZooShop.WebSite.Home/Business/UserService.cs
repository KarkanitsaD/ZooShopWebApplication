using System;
using System.Collections.Generic;
using AutoMapper;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Business.Models;
using ZooShop.Website.Home.Data.Contracts;
using ZooShop.Website.Home.Data.Entities;
using ZooShop.Website.Home.Data.Query;

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
            if (user == null)
            {
                throw new ArgumentNullException();
            }
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
            if (user == null)
            {
                throw new ArgumentNullException();
            }
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

        public IEnumerable<UserDto> GetWithFilter(string firstname, string surname, string lastname, string email)
        {
            Func<UserEntity, bool> filterPredicate = delegate(UserEntity user)
            {
                if (!string.IsNullOrEmpty(firstname))
                {
                    if (!user.FirstName.Contains(firstname))
                        return false;
                }

                if (!string.IsNullOrEmpty(surname))
                {
                    if (!user.Surname.Contains(surname))
                        return false;
                }

                if (!string.IsNullOrEmpty(lastname))
                {
                    if (!user.LastName.Contains(lastname))
                        return false;
                }

                if (!string.IsNullOrEmpty(email))
                {
                    if (!user.Email.Contains(email))
                        return false;
                }

                return true;
            };

            Func<UserEntity, object> sortPredicate = delegate(UserEntity user)
            {
                return user.FirstName;
            };

            QueryParameters<UserEntity> queryParameters = new QueryParameters<UserEntity>()
            {
                FilterRule = new FilterRule<UserEntity>()
                {
                    Expression = filterPredicate
                },
                SortRule = new SortRule<UserEntity>()
                {
                    Order = SortOrder.Ascending,
                    Expression = sortPredicate
                }
            };

            var usersEntity =  _unitOfWork.GetRepository<UserEntity>().Get(queryParameters);
            var usersDto = GetMapper().Map<IEnumerable<UserEntity>, List<UserDto>>(usersEntity);
            return usersDto;
        }
    }
}
