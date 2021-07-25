using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ZooShop.Website.Home.Data;
using Xunit;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Tests
{
    public class RepositoryTests
    {
        [Fact]
        public void Get_User_CheckId()
        {
            //Arrange
            var repository = GetRepository();
            var user = GetUser();
            var expectedId = user.Id;
            repository.Create(user);
            //Act
            var actualId = repository.Get(user.Id).Id;
            //Assert
            Assert.Equal(expectedId, actualId);
        }


        [Fact]
        public void Create_User_CheckAvailability()
        {
            //Arrange
            var repository = GetRepository();
            var expectedUser = GetUser();

            //Act
            repository.Create(expectedUser);

            //Assert
            Assert.Same(expectedUser, repository.Get(expectedUser.Id));
        }



        [Fact]
        public void Delete_User_CheckAvailability()
        {
            //Arrange   
            var repository = GetRepository();
            var expectedUser = GetUser();
            repository.Create(expectedUser);

            //Act
            repository.Delete(expectedUser);

            //Assert
            Assert.NotSame(expectedUser, repository.Get(expectedUser.Id));
        }

        [Fact]
        public void Update_User_CheckChanges()
        {
            //Arrange
            var repository = GetRepository();
            var user = GetUser();
            repository.Create(user);
            var expectedFirstName = "Vadim";

            //Act
            user.FirstName = expectedFirstName;
            repository.Update(user);

            //Assert
            Assert.Equal(expectedFirstName, repository.Get(user.Id).FirstName);
        }

        private static Repository<UserEntity> GetRepository()
        {
            var options = new DbContextOptionsBuilder<ZooShopContext>()
                .UseInMemoryDatabase(databaseName: "TestDb").Options;

            var context = new ZooShopContext(options);

            return new Repository<UserEntity>(context);
        }

        private static UserEntity GetUser()
        {
            return new UserEntity()
            {
                Id = 15,
                FirstName = "Dima",
                Surname = "Karkanitsa",
                LastName = "Michailovcih"
            };
        }
    }
}
