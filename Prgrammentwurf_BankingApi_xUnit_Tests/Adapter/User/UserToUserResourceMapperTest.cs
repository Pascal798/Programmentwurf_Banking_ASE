using System.Collections.Generic;
using _1_Adapter.Adapter.User;
using Xunit;
using _3_Domain.Domain.Entities;

namespace Programmentwurf_BankingApi.Adapter.User.Tests
{
    public class UserToUserResourceMapperTest
    {
        [Fact]
        public void convertToUserListTest()
        {
            var users = CreateUsers();
            var usersArray = users.ToArray();
            var userlist = UserMapper.getInstance().convertToUserList(users).ToArray();
            

            for(int i = 0; i < usersArray.Length; i++)
            {
                Assert.Equal(users[i].Id, userlist[i].Id);
                Assert.Equal(users[i].Name, userlist[i].Name);
                Assert.Equal(users[i].Email, userlist[i].Email);
            }
        }

        private static List<UserEntity> CreateUsers()
        {
            var userEntities = new List<UserEntity>();
            for (int i = 0; i <= 10; i++)
            {
                userEntities.Add(new UserEntity(i, "Test" + i + "@test.com", "Test", "Passw0rd" + i));
            }
            return userEntities;
        }

        [Fact]
        public void applyTest()
        {
            var user = new UserEntity(1, "Test@test.com", "Test", "Passw0rd");
            var userResource = UserMapper.getInstance().apply(user);

            Assert.Equal(user.Id, userResource.Id);
            Assert.Equal(user.Name, userResource.Name);
            Assert.Equal(user.Email, userResource.Email);
        }
    }
}