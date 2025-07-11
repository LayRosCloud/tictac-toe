using TicTacToeService.Repositories;
using TicTacToeService.Repositories.Interfaces;
using TicTacToeService.Tests.Assertions;
using TicTacToeService.Tests.Common;
using TicTacToeService.Tests.Generator;

namespace TicTacToeService.Tests.Repository
{
    public class UserRepositoryTest : TestCommandBase
    {
        private readonly IUserRepository _userRepository;

        public UserRepositoryTest()
        {
            _userRepository = new UserRepository(Context);
        }

        [Fact]
        public async Task FindByName_Bob_HasValue()
        {
            //Arrange
            var name = UserGenerator.NAME_BOB;

            //Act
            var item = await _userRepository.FindByNameAsync(name);

            //Assert
            Assert.NotNull(item);
        }

        [Fact]
        public async Task FindByName_RandomValue_NotValue()
        {
            //Arrange
            var name = "12333333333";

            //Act
            var item = await _userRepository.FindByNameAsync(name);

            //Assert
            Assert.Null(item);
        }

        [Fact]
        public async Task FindById_RandomValue_NotValue()
        {
            //Arrange
            var id = -10;

            //Act
            var item = await _userRepository.FindByIdAsync(id);

            //Assert
            Assert.Null(item);
        }

        [Fact]
        public async Task FindById_1_HasValue()
        {
            //Arrange
            var id = 1;

            //Act
            var item = await _userRepository.FindByIdAsync(id);

            //Assert
            Assert.NotNull(item);
        }

        [Fact]
        public async Task Create_Successful()
        {
            //Arrange
            var user = UserGenerator.GenerateItem();
            user.Id = default;

            //Act
            var item = await _userRepository.CreateAsync(user);
            Context.SaveChanges();
            var findItem = await _userRepository.FindByNameAsync(user.Name);

            //Assert
            Assert.NotNull(findItem);
            UserAssert.AssertEquals(findItem, user);
        }

        [Fact]
        public async Task Remove_Successful()
        {
            //Arrange
            var user = UserGenerator.GenerateItem();
            user.Id = default;

            //Act
            var item = await _userRepository.CreateAsync(user);
            Context.SaveChanges();
            _userRepository.Remove(item);
            Context.SaveChanges();

            var findItem = await _userRepository.FindByNameAsync(user.Name);

            //Assert
            Assert.Null(findItem);
        }
    }
}
