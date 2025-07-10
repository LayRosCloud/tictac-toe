using TicTacToeService.Entities;
using TicTacToeService.Repositories.Interfaces.Generics;

namespace TicTacToeService.Repositories.Interfaces
{
    public interface IParticipantRepository : IFinderRepository<ParticipantEntity, long>, ICreatorRepository<ParticipantEntity>, IRemoveRepository<ParticipantEntity>
    {
        Task<HashSet<ParticipantEntity>> FindAllByGameIdAsync(Guid gameId);
        Task<ParticipantEntity?> FindByGameIdAndUserId(Guid gameId, long userId);
    }
}
