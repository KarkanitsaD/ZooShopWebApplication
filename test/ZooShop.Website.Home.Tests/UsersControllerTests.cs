using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Business.Models;
using ZooShop.Website.Home.Business.QueryModels;
using ZooShop.Website.Home.Controllers;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Tests
{
    public class UsersControllerTests
    {

        private readonly Mock<IUserService> _mockUserService;
        private UsersController _usersController;
        public UsersControllerTests()
        {
            _mockUserService = new Mock<IUserService>();
        }

        //Get([FromQuery] UserQueryModel queryModel = null)
        [Fact]
        public void Get_NullQueryModel_ExecuteGetEmptyServiceMethod()
        {
            //Arrange
            _mockUserService.Setup(s => s.GetAll(It.IsNotNull<UserQueryModel>())).Returns(new List<UserDto>() { new UserDto(), new UserDto() });
            _mockUserService.Setup(s => s.GetAll(null)).Returns(new List<UserDto>(){ new UserDto() });
            _usersController = new UsersController(_mockUserService.Object);

            //Act
            var users = _usersController.Get();

            //Assert
            Assert.Single(users);
        }

        //Get([FromQuery] UserQueryModel queryModel = null)
        [Fact]
        public void Get_NotValidQueryModel_ExecuteGetEmptyServiceMethod()
        {
            //Arrange
            _mockUserService.Setup(s => s.GetAll(It.IsNotNull<UserQueryModel>())).Returns(new List<UserDto>() { new UserDto(), new UserDto() });
            _mockUserService.Setup(s => s.GetAll(null)).Returns(new List<UserDto>(){ new UserDto() });
            _usersController = new UsersController(_mockUserService.Object);

            //Act
            var users = _usersController.Get(new UserQueryModel());

            //Assert
            Assert.Single(users);
        }

        //Get([FromQuery] UserQueryModel queryModel = null)
        [Fact]
        public void Get_ValidQueryModel_ExecuteGetEmptyServiceMethod()
        {
            //Arrange
            _mockUserService.Setup(s => s.GetAll(null)).Returns(new List<UserDto>());
            _mockUserService.Setup(s => s.GetAll(It.IsNotNull<UserQueryModel>())).Returns(new List<UserDto>(){ new UserDto(), new UserDto() });
            _usersController = new UsersController(_mockUserService.Object);

            //Act
            var users = _usersController.Get(new UserQueryModel(){FirstName = "Di"});

            //Assert
            Assert.Equal(2,users.Count());
        }

        //Post([FromBody] UserEntity user)
        [Fact]
        public void Post_NullUserEntity_ThrowsArgumentNullException()
        {
            //Arrange
            _usersController = new UsersController(_mockUserService.Object);

            //Act
            Action act = () => _usersController.Post(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        //Post([FromBody] UserEntity user)
        [Fact]
        public void Post_InvalidUserEntity_ThrowsArgumentNullException()
        {
            //Arrange
            _usersController = new UsersController(_mockUserService.Object);

            //Act
            Action act = () => _usersController.Post(new UserEntity());

            //Assert
            Assert.Throws<ArgumentException>(act);
        }

        //Post([FromBody] UserEntity user)
        [Fact]
        public void Put_NullUserEntity_ThrowsArgumentNullException()
        {
            //Arrange
            _usersController = new UsersController(_mockUserService.Object);

            //Act
            Action act = () => _usersController.Put(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        //Post([FromBody] UserEntity user)
        [Fact]
        public void Put_InvalidUserEntity_ThrowsArgumentNullException()
        {
            //Arrange
            _usersController = new UsersController(_mockUserService.Object);

            //Act
            Action act = () => _usersController.Put(new UserEntity());

            //Assert
            Assert.Throws<ArgumentException>(act);
        }



        //Delete(int id)
        [Theory]
        [InlineData(-3)]
        [InlineData(0)]
        public void Delete_UserWithNotValidId_CatchException(int id)
        {
            //Arrange
            _usersController = new UsersController(_mockUserService.Object);

            //Act
            Action action = () => _usersController.Delete(id);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }

        public static IEnumerable<object[]> GetTestData =>
            new List<object[]>
            {
                new object []{new UserQueryModel(), 2},
                new object []{null, 2},
                new object []{new UserQueryModel(){FirstName = "D"}, 1}
            };
    }
}
