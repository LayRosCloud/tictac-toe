using TicTacToeService.Entities;
using TicTacToeService.Repositories.Interfaces.Generics;

namespace TicTacToeService.Repositories.Interfaces
{
    public interface IGameRepository : IFinderRepository<GameEntity, Guid>, ICreatorRepository<GameEntity>, IRemoveRepository<GameEntity>
    {
        public Task<KeyValuePair<HashSet<GameEntity>, long>> FindAllAsync(int limit, int offset);
    }
}
