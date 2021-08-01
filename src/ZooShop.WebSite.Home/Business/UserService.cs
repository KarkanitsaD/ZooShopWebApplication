using System;
using System.Collections.Generic;
using AutoMapper;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Business.Models;
using ZooShop.Website.Home.Business.QueryModels;
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
                throw new ArgumentNullException(nameof(UserEntity), "User can't be null");
            }
            _unitOfWork.GetRepository<UserEntity>().Create(user);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            if (id < 1)
                throw new ArgumentException("Not valid user id");
            var repository = _unitOfWork.GetRepository<UserEntity>();
            var user = repository.Get(id);
            repository.Delete(user);
            _unitOfWork.Save();
        }

        public UserDto Get(int id)
        {
            return GetMapper().Map<UserEntity, UserDto>(_unitOfWork.GetRepository<UserEntity>().Get(id));
        }

        public IEnumerable<UserDto> GetAll(UserQueryModel queryModel = null)
        {
            if (queryModel == null)
            {
                var users = GetMapper().Map<IEnumerable<UserEntity>, List<UserDto>>(_unitOfWork.GetRepository<UserEntity>().GetAll());
                return users;
            }
            
            var filterRule = GetFilterRule(queryModel);
            var sortRule = GetSortRule(queryModel);

            QueryParameters<UserEntity> queryParameters = new QueryParameters<UserEntity>()
            {
                FilterRule = filterRule,
                SortRule = sortRule
            };

            var userEntities = _unitOfWork.GetRepository<UserEntity>().GetAll(queryParameters);
            var userDtos = GetMapper().Map<IEnumerable<UserEntity>, List<UserDto>>(userEntities);
            return userDtos;
        }

        public void Update(UserEntity user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(UserEntity), "User can't be null");
            if (user.Id < 1)
                throw new ArgumentException(nameof(UserEntity), "User Id should be positive");
            _unitOfWork.GetRepository<UserEntity>().Update(user);
            _unitOfWork.Save();
        }

        private FilterRule<UserEntity> GetFilterRule(UserQueryModel queryModel)
        {
            FilterRule<UserEntity> filterRule = new FilterRule<UserEntity>();

            if (!queryModel.IsValidToFilter())
                filterRule.Expression = x => true;
            else
            {
                Func<UserEntity, bool> filterPredicate = delegate (UserEntity user)
                {
                    if (queryModel.Email != null)
                    {
                        if (!user.Email.Equals(queryModel.Email))
                            return false;
                    }
                    if (queryModel.FirstName != null)
                    {
                        if (!user.FirstName.Contains(queryModel.FirstName))
                            return false;
                    }
                    if (queryModel.Surname != null)
                    {
                        if (!user.Surname.Contains(queryModel.Surname))
                            return false;
                    }
                    if (queryModel.LastName != null)
                    {
                        if (!user.LastName.Contains(queryModel.LastName))
                            return false;
                    }

                    return true;
                };

                filterRule.Expression = u => filterPredicate(u);
            }
            return filterRule;
        }

        private SortRule<UserEntity> GetSortRule(UserQueryModel queryModel)
        {
            SortRule<UserEntity> sortRule = new SortRule<UserEntity>
            {
                Order = SortOrder.Ascending
            };

            return sortRule;
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
