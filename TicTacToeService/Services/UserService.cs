using TicTacToeService.Dtos.User;
using TicTacToeService.Entities;
using TicTacToeService.Mappers;
using TicTacToeService.Repositories;
using TicTacToeService.Repositories.Interfaces;
using TicTacToeService.Utils.Data;

namespace TicTacToeService.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserMapper _userMapper;

        public UserService(DatabaseContext databaseContext, UserMapper userMapper)
        {
            _userRepository = new UserRepository(databaseContext);
            _userMapper = userMapper;
        }

        public async Task<UserEntity> CreateUserAsync(UserCreateDto dto)
        {
            var userCreateDto = new UserCreateDto(dto.Name);
            var userCreateEntity = _userMapper.MapToEntity(userCreateDto);
            var user = await _userRepository.CreateAsync(userCreateEntity);

            return user;
        }

        public async Task<UserEntity?> FindUserByNameAsync(string name)
        {
            var user = await _userRepository.FindByNameAsync(name);
            return user;
        }

        public async Task<UserEntity?> FindUserByIdAsync(long id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            return user;
        }
    }
}
