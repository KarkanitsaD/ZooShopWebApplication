using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Moq;
using Xunit;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Business.Models;
using ZooShop.Website.Home.Controllers;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Tests
{
    public class UsersControllerTests
    {

        [Fact]
        public void Add_NotValidUser_CatchException()
        {
            //Arrange
            var moq = new Mock<IUserService>();
            var notValidUser = new UserEntity() {FirstName = "Dima", Email = "email"};
            UsersController controller = new UsersController(moq.Object);

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => { controller.Post(notValidUser); });
        }
        
        [Fact]
        public void Update_NotValidUser_CatchException()
        {
            //Arrange
            var moq = new Mock<IUserService>();
            var notValidUser = new UserEntity() {FirstName = "Dima", Email = "email"};
            UsersController controller = new UsersController(moq.Object);

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => { controller.Put(notValidUser); });
        }



        [Theory]
        [InlineData(-3)]
        [InlineData(0)]
        public void Delete_UserWithNotValidId_CatchException(int id)
        {
            //Arrange
            var moq = new Mock<IUserService>();

            UsersController controller = new UsersController(moq.Object);
            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => { controller.Delete(id); });
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>()
            {
                new object[] { new UserEntity(){FirstName = "Dima", Email = "email", PasswordHash = "hash"}},
                new object[] { new UserEntity(){FirstName = "Dima", Email = "email"}},
                new object[]{null}
            };


        [Theory]
        [InlineData("name", null, "lastname", "email", 1)]
        [InlineData(null, null, null, null, 2)]
        [InlineData(null, null, null, "aakarkanitsa@gmail.com", 1)]
        public void Get_User_CheckWhatMethodExecute
            (
            string firstname,
            string surname,
            string lastname,
            string email,
            int expectedSize)
        {
            //Arrange
            var serviceMoq = new Mock<IUserService>();
            serviceMoq.Setup(s => s.GetAll()).Returns(GetAllUsers());
            serviceMoq.Setup(s =>
                    s.GetWithFilter(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(GetUsersWithFilter);

            UsersController usersController = new UsersController(serviceMoq.Object);
            //Act

            var list = usersController.Get(firstname, surname, lastname, email);


            //Assert
            Assert.Equal(expectedSize, list.Count());

        }
        private static IEnumerable<UserDto> GetAllUsers()
        {
            return new List<UserDto>()
            {
                new UserDto()
                {

                },
                new UserDto()
                {

                }
            };
        }
        
        private static IEnumerable<UserDto> GetUsersWithFilter()
        {
            return new List<UserDto>()
            {
                new UserDto()
                {

                }
            };
        }



    }
}
