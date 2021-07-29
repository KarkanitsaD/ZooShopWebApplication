using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZooShop.Website.Home.Data;
using Xunit;
using ZooShop.Website.Home.Data.Contracts;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Tests
{
    public class RepositoryTests
    {
        private IRepository<UserEntity> _repository;

        //Get(int id)
        [Theory]
        [InlineData(1, "Dima")]
        [InlineData(2, "Oleg")]
        [InlineData(3, "Kirill")]
        public void GetById_UserEntity_CheckUserEntityFirstName(int id, string expectedFirstName)
        {
            // Arrange
            _repository = GetDefaultUserRepository();
            _repository.CreateRange(new List<UserEntity>()
            {
                new(){Id = 1, FirstName = "Dima"},
                new(){Id = 2, FirstName = "Oleg"},
                new(){Id = 3, FirstName = "Kirill"}
            });

            // Act
            var user = _repository.Get(id);

            // Assert
            Assert.Equal(expectedFirstName, user.FirstName);
        }

        //GetAll
        [Fact]
        public void GetAll_Users_CheckCountUsers()
        {
            _repository = GetDefaultUserRepository();

        }

        //Create(UserEntity user)
        [Fact]
        public void Create_UserEntity_CountsUser()
        {
            //Arrange
            _repository = GetDefaultUserRepository();
            
            //Act
            _repository.CreateRange(new List<UserEntity>() {new UserEntity(){Id = 1, FirstName = "Dima"}});

            //Assert
            Assert.Equal(1, _repository.GetAll().Count());
        }

        //CreateRange(List<UserEntity> users)
        [Fact]
        public void CreateRange_UserEntity_CountsUsersEntities()
        {

        }

        //Delete(UserEntity user)
        [Fact]
        public void Delete_UserEntity_CheckAvailability()
        {

        }

        //Update(UserEntity user)
        [Fact]
        public void Update_UserEntity_CheckChanges()
        {

        }

        private static Repository<UserEntity> GetDefaultUserRepository()
        {
            var options = new DbContextOptionsBuilder<ZooShopContext>()
                .UseInMemoryDatabase(databaseName: "TestDb").Options;

            var context = new ZooShopContext(options);

            return new Repository<UserEntity>(context);
        }

    }
}
