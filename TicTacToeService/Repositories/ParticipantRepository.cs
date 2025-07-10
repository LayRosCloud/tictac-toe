using Microsoft.EntityFrameworkCore;
using TicTacToeService.Entities;
using TicTacToeService.Repositories.Interfaces;
using TicTacToeService.Utils.Data;

namespace TicTacToeService.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly DatabaseContext _database;

        public ParticipantRepository(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<ParticipantEntity> CreateAsync(ParticipantEntity entity)
        {
            var item = await _database.Participants.AddAsync(entity);
            return item.Entity;
        }

        public async Task<HashSet<ParticipantEntity>> FindAllByGameIdAsync(Guid gameId)
        {
            return await _database.Participants.Where(x => x.GameId == gameId).Select(x => new ParticipantEntity
            {
                Id = x.Id,
                Game = x.Game,
                User = x.User,
                UserId = x.UserId,
                GameId = x.GameId,
                SelectedCharacter = x.SelectedCharacter,
                Status = x.Status
            }).ToHashSetAsync();
        }

        public async Task<ParticipantEntity?> FindByGameIdAndUserId(Guid gameId, long userId)
        {
            return await _database.Participants.SingleOrDefaultAsync(x => x.GameId == gameId && x.UserId == userId);
        }

        public async Task<ParticipantEntity?> FindByIdAsync(long id)
        {
            return await _database.Participants.SingleOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(ParticipantEntity entity)
        {
            _database.Participants.Remove(entity);
        }
    }
}
