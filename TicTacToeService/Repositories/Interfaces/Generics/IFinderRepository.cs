namespace TicTacToeService.Repositories.Interfaces.Generics
{
    public interface IFinderRepository<TEntity, VKey> where TEntity : class
    {
        Task<TEntity?> FindByIdAsync(VKey id);
    }
}
