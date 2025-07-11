using Microsoft.EntityFrameworkCore;
using TicTacToeService.Utils.Data;
using TicTacToeService.Entities;
using TicTacToeService.Tests.Generator;

namespace TicTacToeService.Tests.Common
{
    public class TicTacDatabaseContext
    {
        public static DatabaseContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new DatabaseContext(options);
            context.Database.EnsureCreated();
            var users = GenerateUsers(context);
            var games = GenerateGames(context);
            var participants = GenerateParticipants(context, users, games);
            GenerateStages(context, participants);
            return context;
        }

        public static void Destroy(DatabaseContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        private static void GenerateStages(DatabaseContext context, List<ParticipantEntity> list)
        {
            context.Stages.AddRange(StageGenerator.GenerateList(list[0]));
            context.Stages.AddRange(StageGenerator.GenerateList(list[1]));
            context.SaveChanges();
        }

        private static List<ParticipantEntity> GenerateParticipants(DatabaseContext context, List<UserEntity> users, List<GameEntity> games)
        {
            var participants = ParticipantGenerator.GenerateList(games[0], games[1], games[2], users[0], users[1], users[2], users[3]);
            
            context.Participants.AddRange(participants);
            context.SaveChanges();
            return participants;
        }

        private static List<UserEntity> GenerateUsers(DatabaseContext context)
        {
            var list = UserGenerator.GenerateList();
            context.Users.AddRange(list);
            context.SaveChanges();
            return list;
        }

        private static List<GameEntity> GenerateGames(DatabaseContext context)
        {
            var games = GameGenerator.GenerateList(6);
            context.Games.AddRange(games);
            context.SaveChanges();
            return games;
        }

    }
}
