using TicTacToeService.Repositories;
using TicTacToeService.Repositories.Interfaces;
using TicTacToeService.Tests.Assertions;
using TicTacToeService.Tests.Common;
using TicTacToeService.Tests.Generator;

namespace TicTacToeService.Tests.Repository
{
    public class GameRepositoryTest : TestCommandBase
    {
        private readonly IGameRepository _gameRepository;
        
        public GameRepositoryTest()
        {
            _gameRepository = new GameRepository(Context);
        }

        [Fact]
        public async Task FindAllByLimitAndPage_1_Successful()
        {
            //Arrange
            int limit = 5;
            int page = 1;

            //Act
            var games = await _gameRepository.FindAllAsync(limit, limit * page - limit);

            //Assert
            Assert.Equal(limit, games.Key.Count);
            Assert.Equal(6, games.Value);
        }

        [Fact]
        public async Task FindAllByLimitAndPage_2_Successful()
        {
            //Arrange
            int limit = 5;
            int page = 2;

            //Act
            var games = await _gameRepository.FindAllAsync(limit, limit * page - limit);

            //Assert
            const int countElements = 1;
            const int totalElements = 6;

            Assert.Equal(countElements, games.Key.Count);
            Assert.Equal(totalElements, games.Value);
        }

        [Fact]
        public async Task FindById_HasValue()
        {
            //Arrange
            var id = Guid.NewGuid();
            var game = GameGenerator.GenerateItem(id);
            var createdGame = await _gameRepository.CreateAsync(game);
            Context.SaveChanges();

            //Act
            var findedGame = await _gameRepository.FindByIdAsync(id);

            //Assert
            Assert.NotNull(findedGame);
            GameAssert.AssertEquals(createdGame, findedGame);
        }

        [Fact]
        public async Task FindById_NoValue()
        {
            //Arrange
            var id = Guid.NewGuid();

            //Act
            var findedGame = await _gameRepository.FindByIdAsync(id);

            //Assert
            Assert.Null(findedGame);
        }

        [Fact]
        public async Task CreateGame_Successful()
        {
            //Arrange
            var id = Guid.NewGuid();
            var game = GameGenerator.GenerateItem(id);

            //Act
            var createdGame = await _gameRepository.CreateAsync(game);
            Context.SaveChanges();


            //Assert
            Assert.NotNull(createdGame);
            GameAssert.AssertEquals(createdGame, game);
        }

        [Fact]
        public async Task RemoveGame_Successful()
        {
            //Arrange
            var id = Guid.NewGuid();
            var game = GameGenerator.GenerateItem(id);
            var createadGame = await _gameRepository.CreateAsync(game);
            Context.SaveChanges();
            //Act
            _gameRepository.Remove(createadGame);
            Context.SaveChanges();
            game = await _gameRepository.FindByIdAsync(id);
            //Assert
            Assert.Null(game);
        }
    }
}
