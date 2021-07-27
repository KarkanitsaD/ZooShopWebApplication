using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using Moq;
using Xunit;
using ZooShop.Website.Home.Business;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Data.Contracts;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Tests
{
    public class UserServiceTests
    {

        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        public UserServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void GetAll_Users_CheckOutputCollectionSize()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.GetRepository<UserEntity>().GetAll()).Returns(GetUsers());

            UserService userService = new UserService(unitOfWorkMock.Object);

            int expectedCollectionSize = 3;
            // Act
            var usersDtoCollection = userService.GetAll();

            // Assert
            Assert.Equal(expectedCollectionSize, usersDtoCollection.Count());
        }



        [Fact]
        public void Add_NullUser_CatchException()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            UserService userService = new UserService(unitOfWorkMock.Object);

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => { userService.Create(null); });
        }
        
        [Fact]
        public void Update_NullUser_CatchException()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            UserService userService = new UserService(unitOfWorkMock.Object);

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => { userService.Update(null); });
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

        public static IEnumerable<object[]> AddUpdateUsers =>
            new List<object[]>()
            {
                new object[] { new UserEntity(){FirstName = "Dima", Email = "email", PasswordHash = "hash"}},
                new object[] { new UserEntity(){FirstName = "Dima", Email = "email"}},
                new object[] {null}
            };


    }
}
