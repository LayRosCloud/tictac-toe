using TicTacToeService.Entities;
using TicTacToeService.Repositories.Interfaces.Generics;

namespace TicTacToeService.Repositories.Interfaces
{
    public interface IStageRepository : IFinderRepository<StageEntity, long>, ICreatorRepository<StageEntity>, IRemoveRepository<StageEntity>
    {
        Task<StageEntity?> FindByCoordinatesXAndYAsync(int x, int y);
        Task<HashSet<StageEntity>> FindAllByParticipantIds(HashSet<long> participantsIds);
    }
}
