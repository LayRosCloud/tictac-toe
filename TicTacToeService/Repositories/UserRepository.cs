using Microsoft.EntityFrameworkCore;
using TicTacToeService.Entities;
using TicTacToeService.Repositories.Interfaces;
using TicTacToeService.Utils.Data;

namespace TicTacToeService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _database;

        public UserRepository(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<UserEntity> CreateAsync(UserEntity entity)
        {
            var item = await _database.Users.AddAsync(entity);
            return item.Entity;
        }

        public async Task<UserEntity?> FindByIdAsync(long id)
        {
            return await _database.Users.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<UserEntity?> FindByNameAsync(string name)
        {
            return await _database.Users.SingleOrDefaultAsync(x => x.Name.Equals(name));
        }

        public void Remove(UserEntity entity)
        {
            _database.Users.Remove(entity);
        }
    }
}
