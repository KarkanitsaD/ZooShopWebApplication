using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Moq;
using Xunit;
using ZooShop.Website.Home.Business.Contracts;
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



    }
}
