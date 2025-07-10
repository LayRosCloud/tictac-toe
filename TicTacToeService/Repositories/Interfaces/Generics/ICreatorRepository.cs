namespace TicTacToeService.Repositories.Interfaces.Generics
{
    public interface ICreatorRepository<TEntity>
    {
        Task<TEntity> CreateAsync(TEntity entity);
    }
}