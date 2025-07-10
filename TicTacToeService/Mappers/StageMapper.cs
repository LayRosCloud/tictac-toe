using TicTacToeService.Dtos.Stage;
using TicTacToeService.Entities;

namespace TicTacToeService.Mappers
{
    public class StageMapper
    {
        private readonly UserMapper _userMapper;
        private readonly GameMapper _gameMapper;

        public StageMapper(UserMapper userMapper, GameMapper gameMapper)
        {
            _userMapper = userMapper;
            _gameMapper = gameMapper;
        }

        public StageResponseDto MapToResponseDto(StageEntity stage, ParticipantEntity participant) 
        {
            StageResponseDto dto = new StageResponseDto
            {
                Id = stage.Id,
                CoordinateX = stage.CoordinateX,
                CoordinateY = stage.CoordinateY,
                SuppliedSymbol = stage.SuppliedSymbol,
                Game = _gameMapper.MapToResponseDto(participant.Game!),
                User = _userMapper.MapToResponseDto(participant.User!),
            };
            return dto;
        }
    }
}
