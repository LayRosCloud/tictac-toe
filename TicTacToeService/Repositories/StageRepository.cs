using Microsoft.EntityFrameworkCore;
using TicTacToeService.Entities;
using TicTacToeService.Repositories.Interfaces;
using TicTacToeService.Utils.Data;

namespace TicTacToeService.Repositories
{
    public class StageRepository : IStageRepository
    {
        private readonly DatabaseContext _database;

        public StageRepository(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<StageEntity> CreateAsync(StageEntity entity)
        {
            var item = await _database.Stages.AddAsync(entity);
            return item.Entity;
        }

        public async Task<HashSet<StageEntity>> FindAllByParticipantIds(HashSet<long> participantsIds)
        {
            var items = await _database.Stages.Where(x => participantsIds.Contains(x.ParticipantId)).ToHashSetAsync();
            return items;
        }

        public async Task<StageEntity?> FindByCoordinatesXAndYAsync(int x, int y)
        {
            return await _database.Stages.Select(x => new StageEntity
            {
                Id = x.Id,
                CoordinateX = x.CoordinateX,
                CoordinateY = x.CoordinateY,
                ParticipantId = x.ParticipantId,
                SuppliedSymbol = x.SuppliedSymbol,
                Participant = x.Participant
            }).SingleOrDefaultAsync(stage => stage.CoordinateY == y && stage.CoordinateX == x);
        }

        public async Task<StageEntity?> FindByIdAsync(long id)
        {
            return await _database.Stages.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public void Remove(StageEntity entity)
        {
            _database.Stages.Remove(entity);
        }
    }
}
