using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using ZooShop.Website.Home.Business.Models;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Business.Mappers
{
    public class UserMapper: MapperConfiguration
    {
        public UserMapper() : base(cfg =>
            cfg.CreateMap<UserEntity, UserDto>()
                .ForMember("FullName", opt => opt.MapFrom(u => u.FirstName + " " + u.LastName + " " + u.Surname))
                .ForMember("Id", opt => opt.MapFrom(u => u.Id))
                .ForMember("Email", opt => opt.MapFrom(u => u.Email))
        )
        {
        }

        public Mapper GetMapper()
        {
            return new Mapper(this);
        }
    }
}
