using Microsoft.EntityFrameworkCore;
using TicTacToeService.Entities;

namespace TicTacToeService.Utils.Data
{
    public class DatabaseContext : DbContext
    { 
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ParticipantEntity> Participants { get; set; }
        public DbSet<StageEntity> Stages { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) :base(options)
        {
        }

        public DatabaseContext()
        {
        }

    }
}
