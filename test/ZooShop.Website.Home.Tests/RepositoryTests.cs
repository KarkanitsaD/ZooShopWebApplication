using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZooShop.Website.Home.Data;
using Xunit;
using ZooShop.Website.Home.Data.Contracts;
using ZooShop.Website.Home.Data.Entities;
using ZooShop.Website.Home.Data.Query;

namespace ZooShop.Website.Home.Tests
{
    public class RepositoryTests
    {
        private IRepository<UserEntity> _repository;
        private ZooShopContext _context;

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
            _repository.Create(new UserEntity(){Id = 1, FirstName = "Dima"});

            _context.SaveChanges();

            //Assert
            Assert.Equal(1, _repository.GetAll().Count());
        }

        //CreateRange(List<UserEntity> users)
        [Fact]
        public void CreateRange_UserEntity_CountsUsersEntities()
        {
            //Arrange
            _repository = GetDefaultUserRepository();
            int expectedLength = 2;

            //Act
            _repository.CreateRange(new List<UserEntity>()
            {
                new UserEntity()
                {
                    FirstName = "Dima"
                },
                new UserEntity()
                {
                    FirstName = "Karina"
                }
            });

            _context.SaveChanges();

            //Assert
            Assert.Equal(expectedLength, _repository.GetAll().Count());
        }

        //Delete(UserEntity user)
        [Fact]
        public void Delete_UserEntity_CheckAvailability()
        {
            //Arrange
            _repository = GetDefaultUserRepository();

            UserEntity user1 = new UserEntity()
            {
                Id = 1,
                FirstName = "Maria"
            };
            UserEntity user2 = new UserEntity()
            {
                Id = 2,
                FirstName = "Boris"
            };

            _repository.CreateRange(new List<UserEntity>()
            {
                user1,
                user2
            });

            //Act
            _repository.Delete(user2);
            _context.SaveChanges();

            //Assert
            Assert.NotEqual(user2, _repository.Get(2));

        }

        //Update(UserEntity user)
        [Fact]
        public void Update_UserEntity_CheckChanges()
        {
            //Arrange
            _repository = GetDefaultUserRepository();
            UserEntity user = new UserEntity(){Id = 1, FirstName = "Dima", Surname = "Karkanitsa"};
            _repository.Create(user);
            _context.SaveChanges();

            //Act
            user.FirstName = "Kirill";
            _repository.Update(user);
            _context.SaveChanges();

            //Assert
            Assert.Equal("Kirill", _repository.Get(1).FirstName);

        }

        //Update(UserEntity user)
        [Fact]
        public void Update_UserEntityUsingDifferentContexts_CheckChanges()
        {
            //Arrange
            _repository = GetDefaultUserRepository();
            UserEntity user = new UserEntity() { FirstName = "Dima", Surname = "Karkanitsa" };
            _repository.Create(user);
            _context.SaveChanges();

            _repository = GetDefaultUserRepository();
            //Act
            user.FirstName = "Kirill";
            _repository.Update(user);
            _context.SaveChanges();

            //Assert
            Assert.Equal("Kirill", _repository.Get(1).FirstName);
        }

        //Update(UserEntity user)
        [Fact]
        public void Update_UserEntityWithSimilarUsersInDB_CheckChanges()
        {
            //Arrange
            var user1 = new UserEntity() {Id = 1, FirstName = "Kirill"};
            var user2 = new UserEntity() {Id = 2, FirstName = "Kirill"};

            _repository = GetDefaultUserRepository();

            _repository.CreateRange(new List<UserEntity>()
            {
                user1, user2
            });
            _context.SaveChanges();

            _repository = GetDefaultUserRepository();

            //Act
            var userToUpdate = _repository.Get(1);
            userToUpdate.FirstName = "Vova";
            _repository.Update(userToUpdate);
            _context.SaveChanges();

            //Assert
            Assert.NotEqual(_repository.Get(1).FirstName, _repository.Get(2).FirstName);
        }

        //Update(UserEntity user)
        [Fact]
        public void Update_UserEntityWithNewUser_CheckChanges()
        {
            //Arrange
            var user1 = new UserEntity() { Id = 1, FirstName = "Kirill", Surname = "Surname1"};
            var user2 = new UserEntity() { Id = 2, FirstName = "Kirill", Surname = "Surname1"};

            _repository = GetDefaultUserRepository();

            _repository.CreateRange(new List<UserEntity>()
            {
                user1, user2
            });
            _context.SaveChanges();

            _repository = GetDefaultUserRepository();

            //Act
            var userToUpdate = new UserEntity() {Id = 2, Surname = "Surname2"};
            _repository.Update(userToUpdate);
            _context.SaveChanges();

            //Assert
            Assert.Null( _repository.Get(2).FirstName);
        }

        [Theory]
        [MemberData(nameof(GetWithFilterTestData))]
        public void GetWithFilter_UserEntity_ReturnsFilteredUsers(List<UserEntity> users, string stringToFilter, int expectedCollectionSize)
        {
            //Arrange
            _repository = GetDefaultUserRepository();
            _repository.CreateRange(users);
            _context.SaveChanges();

            QueryParameters<UserEntity> queryParameters = new QueryParameters<UserEntity>
            {
                FilterRule = new FilterRule<UserEntity>()
                {
                    Expression = x => x.FirstName.Contains(stringToFilter)
                }
            };

            var u = _repository.GetAll();

            //Act
            var usersCollection  = _repository.GetAll(queryParameters);
            //Assert
            Assert.Equal(expectedCollectionSize, usersCollection.Count());
        }

        private Repository<UserEntity> GetDefaultUserRepository()
        {
            var options = new DbContextOptionsBuilder<ZooShopContext>()
                .UseInMemoryDatabase(databaseName: "TestDb").Options;

            _context = new ZooShopContext(options);

            return new Repository<UserEntity>(_context);
        }

        public static IEnumerable<object[]> GetWithFilterTestData()
        {
            var users1 = new List<UserEntity>()
            {
                new UserEntity(){FirstName = "Dima"},
                new UserEntity(){FirstName = "Dima"},
                new UserEntity(){FirstName = "Oleg"},
            };
            var stringToFilterFirstName1 = "Dim";
            int expectedCollectionSize1 = 2;


            var users2 = new List<UserEntity>()
            {
                new UserEntity(){FirstName = "Dima"},
                new UserEntity(){FirstName = "Dima"},
                new UserEntity(){FirstName = "Oleg"},
            };
            var stringToFilterFirstName2 = "Ol";
            int expectedCollectionSize2 = 1;

            List<object[]> objects = new List<object[]>()
            {
                new object[]{users1, stringToFilterFirstName1, expectedCollectionSize1},
                new object[]{users2, stringToFilterFirstName2, expectedCollectionSize2},
            };
            return objects;
        }
    }
}
