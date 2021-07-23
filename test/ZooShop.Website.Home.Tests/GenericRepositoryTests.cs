using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ZooShop.Website.Home.Data;
using Xunit;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Tests
{
    public class GenericRepositoryTests
    {
        [Fact]
        public void Create_User_CheckAvailability()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ZooShopContext>()
                .UseInMemoryDatabase(databaseName: "TestDb").Options;

            var context = new ZooShopContext(options);

            Repository<UserEntity> repository = new(context);

            var user = new UserEntity()
            {
                Id = 12,
                FirstName = "Dima",
                Surname = "Karkanitsa",
                LastName = "Michailovich",
                Email = "aakarkanica#gmail.com"
            };

            //Act
            repository.Create(user);
            var loadingUser = repository.Get(12);

            //Assert
            Assert.Equal(user, loadingUser);
        }

        [Fact]
        public void Delete_User_CheckAvailability()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ZooShopContext>()
                .UseInMemoryDatabase(databaseName: "TestDb").Options;

            var context = new ZooShopContext(options);

            Repository<UserEntity> repository = new(context);

            var user = new UserEntity()
            {
                Id = 12,
                FirstName = "Dima",
                Surname = "Karkanitsa",
                LastName = "Michailovich",
                Email = "aakarkanica#gmail.com"
            };
            repository.Create(user);

            //Act
            repository.Delete(user);
            var loadingUser = repository.Get(12);

            //Assert
            Assert.Equal(0, loadingUser.Id);
        }

        [Fact]
        public void Delete_NonExistentUser_DoNotCatchException()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ZooShopContext>()
                .UseInMemoryDatabase(databaseName: "TestDb").Options;

            var context = new ZooShopContext(options);

            Repository<UserEntity> repository = new(context);

            var user = new UserEntity()
            {
                Id = 444,
            };

            //Act

            //Assert
            Assert.Throws<Exception>(() => repository.Delete(user));
        }

        [Fact]
        public void Get_NonExistentUser_ReturnEmptyUser()
        {

        }

        [Fact]
        public void Update_User_CheckRenewal()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ZooShopContext>()
                .UseInMemoryDatabase(databaseName: "TestDb").Options;

            var context = new ZooShopContext(options);

            Repository<UserEntity> repository = new(context);

            repository.CreateRange(new List<UserEntity>()
            {
                new UserEntity()
                {
                    Id = 1,
                    FirstName = "Dima",
                    LastName = "Michailovich",
                    Surname = "Karkanitsa"
                },
                new UserEntity()
                {
                    Id = 2,
                    FirstName = "Vova",
                    LastName = "Petorv",
                    Surname = "Romanets"
                },
                new UserEntity()
                {
                    Id = 3,
                    FirstName = "Kirill",
                    LastName = "Ivanov",
                    Surname = "Aleksandrovich"
                },
            });
            //Act
            var user = repository.Get(1);
            user.LastName = "ChangeLastName";

            //Assert
            Assert.Equal("ChangeLastName", repository.Get(1).LastName);
        }
    }
}
