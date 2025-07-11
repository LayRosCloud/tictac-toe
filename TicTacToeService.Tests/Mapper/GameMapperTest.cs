using TicTacToeService.Mappers;
using TicTacToeService.Tests.Assertions;
using TicTacToeService.Tests.Generator;

namespace TicTacToeService.Tests.Mapper
{
    public class GameMapperTest
    {
        private readonly GameMapper _gameMapper;

        public GameMapperTest()
        {
            _gameMapper = new GameMapper();
        }

        [Fact]
        public void MapToResponseDtoGame_Successful()
        {
            //Arrange
            var game = GameGenerator.GenerateItem();

            //Act
            var response = _gameMapper.MapToResponseDto(game);

            //Assert
            GameAssert.AssertGame(game, response);
        }

        [Fact]
        public void MapToEntityGame_Successful()
        {
            //Arrange
            var game = GameGenerator.GenerateDto();

            //Act
            var response = _gameMapper.MapToEntity(game);

            //Assert
            GameAssert.AssertGame(response, game);
        }
    }
}
