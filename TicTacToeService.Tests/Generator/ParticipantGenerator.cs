using TicTacToeService.Entities;

namespace TicTacToeService.Tests.Generator
{
    public class ParticipantGenerator
    {
        public static ParticipantEntity GenerateItem(UserEntity user, GameEntity game, GameStatus status, char symbol)
        {
            Random random = new Random();
            return new ParticipantEntity
            {
                Id = random.NextInt64(0, 10000),
                SelectedCharacter = symbol,
                UserId = user.Id,
                GameId = game.Id,
                User = user,
                Game = game,
                Status = status
            };
        }

        public static List<ParticipantEntity> GenerateList()
        {
            var game1 = GameGenerator.GenerateItem();
            var game2 = GameGenerator.GenerateItem();
            var game3 = GameGenerator.GenerateItem();

            var user1 = UserGenerator.GenerateItem();
            var user2 = UserGenerator.GenerateItem();
            var user3 = UserGenerator.GenerateItem();
            var user4 = UserGenerator.GenerateItem();

            return new List<ParticipantEntity>
            {
                GenerateItem(user1, game1, GameStatus.Playing, 'x'),
                GenerateItem(user2, game1, GameStatus.Playing, 'o'),
                GenerateItem(user3, game2, GameStatus.Playing, 'x'),
                GenerateItem(user4, game2, GameStatus.Playing, 'o'),
                GenerateItem(user2, game3, GameStatus.Draw, 'o'),
                GenerateItem(user3, game3, GameStatus.Draw, 'x'),
            };
        }

        public static List<ParticipantEntity> GenerateList(GameEntity game1, 
                                                        GameEntity game2, 
                                                        GameEntity game3,
                                                        UserEntity user1,
                                                        UserEntity user2,
                                                        UserEntity user3,
                                                        UserEntity user4)
        {

            return new List<ParticipantEntity>
            {
                GenerateItem(user1, game1, GameStatus.Playing, 'x'),
                GenerateItem(user2, game1, GameStatus.Playing, 'o'),
                GenerateItem(user3, game2, GameStatus.Playing, 'x'),
                GenerateItem(user4, game2, GameStatus.Playing, 'o'),
                GenerateItem(user2, game3, GameStatus.Draw, 'o'),
                GenerateItem(user3, game3, GameStatus.Draw, 'x'),
            };
        }
    }
}
