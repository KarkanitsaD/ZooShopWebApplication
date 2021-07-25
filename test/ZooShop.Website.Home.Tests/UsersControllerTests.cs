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
        [Theory]
        [MemberData(nameof(Data))]
        public void Add_ValidOrNotValidUser_CatchException(UserEntity user, int statusCode)
        {
            //Arrange
            var moq = new Mock<IUserService>();

            UsersController controller = new UsersController(moq.Object);

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => {controller.Post(user);});
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Update_ValidOrNotValidUser_CatchException(UserEntity user)
        {
            //Arrange
            var moq = new Mock<IUserService>();

            UsersController controller = new UsersController(moq.Object);

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => { controller.Put(user); });
        }

        [Theory]
        [InlineData(-3)]
        [InlineData(0)]
        public void Delete_UserWithNegativeId_CatchE(int id)
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
            };



    }
}
