using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using ZooShop.Website.Home.Business;
using ZooShop.Website.Home.Data;
using ZooShop.Website.Home.Data.Contracts;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Tests
{
    public class UserServiceTests
    {

        [Fact]
        public void GetAll_Users_CheckObjectTypeInCollection()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.GetRepository<UserEntity>().GetAll()).Returns(GetUsers());

            int expectedCollectionSize = 3;
            UserService userService = new UserService(unitOfWorkMock.Object);
            // Act
            var usersDtoCollection = userService.GetAll();

            // Assert
            Assert.Equal(expectedCollectionSize, usersDtoCollection.Count());
        }

        private static IEnumerable<UserEntity> GetUsers()
        {
            return new List<UserEntity>()
            {
                new UserEntity()
                {
                    FirstName = "Dima",
                    Surname = "Karkanitsa",
                    LastName = "Michailovich"
                },
                new UserEntity()
                {
                    FirstName = "Vova",
                    Surname = "Kalinin",
                    LastName = "Viktorovich"
                },
                new UserEntity()
                {
                    FirstName = "Kirill",
                    Surname = "Petrov",
                    LastName = "Petrovich"
                }
            };
        }

        private static ZooShopContext GetContext()
        {
            var options = new DbContextOptionsBuilder<ZooShopContext>()
                .UseInMemoryDatabase(databaseName: "TestDb").Options;

            var context = new ZooShopContext(options);
            return context;
        }
    }
}
