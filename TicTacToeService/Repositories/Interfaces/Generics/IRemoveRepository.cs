namespace TicTacToeService.Repositories.Interfaces.Generics
{
    public interface IRemoveRepository<TEntity>
    {
        void Remove(TEntity entity);
    }
}