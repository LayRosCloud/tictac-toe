using Microsoft.EntityFrameworkCore;
using TicTacToeService.Entities;
using TicTacToeService.Repositories.Interfaces;
using TicTacToeService.Utils.Data;
using TicTacToeService.Utils.Time;

namespace TicTacToeService.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly DatabaseContext _database;

        public GameRepository(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<KeyValuePair<HashSet<GameEntity>, long>> FindAllAsync(int limit, int offset)
        {
            var items = await _database.Games.Skip(offset).Take(limit).ToHashSetAsync();
            var totalCount = await _database.Games.CountAsync();
            return new KeyValuePair<HashSet<GameEntity>, long>(items, totalCount);
        }

        public async Task<GameEntity?> FindByIdAsync(Guid id)
        {
            return await _database.Games.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<GameEntity> CreateAsync(GameEntity entity)
        {
            entity.CreatedAt = TimeUtils.GetTimeFromUtc();
            var item = await _database.Games.AddAsync(entity);
            return item.Entity;
        }

        public void Remove(GameEntity entity)
        {
            _database.Games.Remove(entity);
        }

    }
}
