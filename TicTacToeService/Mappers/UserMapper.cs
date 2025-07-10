using TicTacToeService.Dtos.User;
using TicTacToeService.Entities;

namespace TicTacToeService.Mappers
{
    public class UserMapper
    {
        public UserEntity MapToEntity(UserCreateDto dto)
        {
            var user = new UserEntity
            {
                Name = dto.Name
            };
            return user;
        }

        public UserResponseDto MapToResponseDto(UserEntity entity)
        {
            var user = new UserResponseDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
            return user;
        }
    }
}
