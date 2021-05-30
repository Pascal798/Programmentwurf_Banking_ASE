using System.Collections.Generic;
using _3_Domain.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Programmentwurf_BankingApi.Plugin;
using Programmentwurf_BankingApi.Plugin.User;
using Xunit;

namespace Programmentwurf_BankingApi_xUnit_Tests.Plugin
{
    public class UserRepositoryBridgeTests
    {
        [Fact]
        public async void CreateUserTest()
        {
            var options = new DbContextOptionsBuilder<BankingContext>()
                .UseInMemoryDatabase(databaseName: "CreateUserTest")
                .Options;

            var context = new BankingContext(options);

            var user = new UserEntity(1, "Test@test.com", "Test", "Passw0rd");

            var query = new UserRepositoryImpl(context);

            await query.registrieren(user);
            var result = context.Users.Find(user.Id);

            Assert.Equal(user.Id, result.Id);
            Assert.Equal(user.Name, result.Name);
            Assert.Equal(user.Email, result.Email);
            Assert.Equal(user.Password, result.Password);
        }
        [Fact]
        public async void FindAllUsersTest()
        {
            var options = new DbContextOptionsBuilder<BankingContext>()
                .UseInMemoryDatabase(databaseName: "FindAllUsersTest")
                .Options;

            var context = new BankingContext(options);

            var users = GetUsers();
            context.Users.AddRange(users);
            await context.SaveChangesAsync();

            var query = new UserRepositoryImpl(context);

            var result = await query.findAllUsers();

            Assert.Equal(4, result.Count);

            for (int i = 0; i < users.Count; i++)
            {
                Assert.Equal(users[i].Id, result[i].Id);
                Assert.Equal(users[i].Name, result[i].Name);
                Assert.Equal(users[i].Email, result[i].Email);
                Assert.Equal(users[i].Password, result[i].Password);
            }
        }
        private List<UserEntity> GetUsers()
        {
            var users = new[]
            {
                new UserEntity(1, "Test1@test.com", "Test", "Passw0rd"),
                new UserEntity(2, "Test2@test.com", "Test", "Passw0rd"),
                new UserEntity(3, "Test3@test.com", "Test", "Passw0rd"),
                new UserEntity(4, "Test4@test.com", "Test", "Passw0rd")
            };
            List<UserEntity> userList = new List<UserEntity>();
            userList.AddRange(users);
            return userList;
        }
    }
        
}