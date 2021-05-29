using Moq;
using Programmentwurf_BankingApi.Plugin;
using Programmentwurf_BankingApi.Plugin.User;
using System.Threading.Tasks;
using _3_Domain.Domain.Entities;
using Xunit;

namespace Programmentwurf_BankingApi_Mock_Tests.Plugin.User
{
    public class UserRepositoryBridgeTests
    {
        private readonly UserRepositoryImpl _impl;
        private readonly Mock<IBankingContext> _bankingContextMock = new Mock<IBankingContext>();

        public UserRepositoryBridgeTests()
        {
            _impl = new UserRepositoryImpl(_bankingContextMock.Object);
        }
        [Fact]
        public async Task FindByIdTest()
        {
            //Arrange
            var user = new UserEntity(1, "Test@test.com", "Test", "Passw0rd");
            _bankingContextMock.Setup(x => x.Users.FindAsync(user.Id))
                .ReturnsAsync(user);


            _bankingContextMock.Object.Users.Add(user);

            //Act
            var resultUser = await _impl.findById(user.Id);


            //Assert
            Assert.Equal(user.Name, resultUser.Name);
            Assert.Equal(user.Email, resultUser.Email);
            Assert.Equal(user.Password, resultUser.Password);
        }
    }
}
