using TicTacToeService.Dtos.Game;
using TicTacToeService.Entities;
using TicTacToeService.Utils.Time;

namespace TicTacToeService.Tests.Generator
{
    public class GameGenerator
    {

        public static List<GameEntity> GenerateList(int size)
        {
            var games = new List<GameEntity>();

            for (int i = 0; i < size; i++)
            {
                games.Add(GenerateItem());
            }

            return games;
        }

        public static GameEntity GenerateItem()
        {
            Random random = new Random();
            var size = random.Next(3, 32);
            return new GameEntity
            {
                Id = Guid.NewGuid(),
                CreatedAt = TimeUtils.GetTimeFromUtc(),
                FinishLineSize = size,
                Size = size,
                CurrentStage = 0,
            };
        }

        public static GameEntity GenerateItem(Guid id)
        {
            Random random = new Random();
            var size = random.Next(3, 32);
            return new GameEntity
            {
                Id = id,
                CreatedAt = TimeUtils.GetTimeFromUtc(),
                FinishLineSize = size,
                Size = size,
                CurrentStage = 0,
            };
        }

        public static GameCreateDto GenerateDto()
        {
            Random random = new Random();
            var size = random.Next(3, 32);
            return new GameCreateDto
            {
                FinishLineSize = size,
                Size = size,
            };
        }
    }
}
