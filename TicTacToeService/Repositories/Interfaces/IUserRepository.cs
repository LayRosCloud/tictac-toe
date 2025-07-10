using TicTacToeService.Entities;
using TicTacToeService.Repositories.Interfaces.Generics;

namespace TicTacToeService.Repositories.Interfaces
{
    public interface IUserRepository : IFinderRepository<UserEntity, long>, ICreatorRepository<UserEntity>, IRemoveRepository<UserEntity>
    {
        public Task<UserEntity?> FindByNameAsync(string name);
    }
}
