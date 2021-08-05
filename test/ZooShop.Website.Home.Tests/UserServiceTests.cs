using System;
using System.Collections.Generic;
using System.Linq;
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
        private IUserService _userService;

        public UserServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void GetAll_Users_CheckOutputCollectionSize()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.GetRepository<UserEntity>().GetAll(null)).Returns(GetUsers());

            UserService userService = new UserService(unitOfWorkMock.Object);

            int expectedCollectionSize = 3;
            // Act
            var usersDtoCollection = userService.GetAll();

            // Assert
            Assert.Equal(expectedCollectionSize, usersDtoCollection.Count());
        }

        
        //Create(UserEntity user)
        [Fact]
        public void Create_NullUserEntity_ThrowsArgumentNullException()
        {
            //Arrange
            _userService = new UserService(_mockUnitOfWork.Object);
            
            //Act
            Action action = () => _userService.Create(null);

            //Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        //Delete(int id)
        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void DeleteById_NegativeOrZeroId_ThrowsArgumentException(int id)
        {
            //Arrange
            _userService = new UserService(_mockUnitOfWork.Object);

            //Act
            Action action = () => _userService.Delete(id);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }

        //Update(UserEntity user)
        [Fact]
        public void Update_NullUser_ThrowsArgumentNullException()
        {
            //Arrange
            _userService = new UserService(_mockUnitOfWork.Object);

            // Act
            Action action = () => _userService.Update(null);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        //Update(UserEntity user)
        [Fact]
        public void Update_UserWithZeroOrNegativeId_ThrowsArgumentException()
        {
            //Arrange
            _userService = new UserService(_mockUnitOfWork.Object);

            // Act
            Action action = () => _userService.Update(new UserEntity(){Id = -2});

            // Assert
            Assert.Throws<ArgumentException>(action);
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
