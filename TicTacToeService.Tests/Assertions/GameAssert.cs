using TicTacToeService.Dtos.Game;
using TicTacToeService.Entities;

namespace TicTacToeService.Tests.Assertions
{
    public class GameAssert
    {
        public static void AssertGame(GameEntity game, GameResponseDto dto)
        {
            Assert.Equal(game.Id, dto.Id);
            Assert.Equal(game.Size, dto.Size);
            Assert.Equal(game.CreatedAt, dto.CreatedAt);
            Assert.Equal(game.FinishedAt, dto.FinishedAt);
            Assert.Equal(game.CurrentStage, dto.CurrentStage);
            Assert.Equal(game.FinishLineSize, dto.FinishLineSize);
        }

        public static void AssertEquals(GameEntity game, GameEntity game1)
        {
            Assert.Equal(game.Id, game1.Id);
            Assert.Equal(game.Size, game1.Size);
            Assert.Equal(game.CreatedAt, game1.CreatedAt);
            Assert.Equal(game.FinishedAt, game1.FinishedAt);
            Assert.Equal(game.CurrentStage, game1.CurrentStage);
            Assert.Equal(game.FinishLineSize, game1.FinishLineSize);
        }

        public static void AssertGame(GameEntity game, GameCreateDto dto)
        {
            Assert.Equal(game.Size, dto.Size);
            Assert.Equal(game.FinishLineSize, dto.FinishLineSize);
        }
    }
}
