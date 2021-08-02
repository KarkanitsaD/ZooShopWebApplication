using System.Collections.Generic;
using System.Threading.Tasks;
using ZooShop.Website.Home.Business.Models;
using ZooShop.Website.Home.Business.QueryModels;
using ZooShop.Website.Home.Data.Entities;


namespace ZooShop.Website.Home.Business.Contracts
{
    public interface IUserService
    {
        void Create(UserEntity user);
        Task CreateAsync(UserEntity user);
        void Update(UserEntity user);
        Task UpdateAsync(UserEntity user);
        void Delete(int id);
        Task DeleteAsync(int id);
        UserDto Get(int id);
        Task<UserDto> GetAsync(int id);
        IEnumerable<UserDto> GetAll(UserQueryModel queryModel = null);
        Task<IEnumerable<UserDto>> GetAllAsync(UserQueryModel queryModel = null);
    }
}
