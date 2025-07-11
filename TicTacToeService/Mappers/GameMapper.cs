using TicTacToeService.Dtos.Game;
using TicTacToeService.Entities;

namespace TicTacToeService.Mappers
{
    public class GameMapper
    {

        public HashSet<GameResponseDto> MapToResponseDto(IEnumerable<GameEntity> games)
        {
            var list = new HashSet<GameResponseDto>();
            foreach (var game in games)
            {
                list.Add(MapToResponseDto(game));
            }
            return list;
        }

        public GameResponseDto MapToResponseDto(GameEntity game)
        {
            var response = new GameResponseDto
            {
                Id = game.Id,
                Size = game.Size,
                CurrentStage = game.CurrentStage,
                CreatedAt = game.CreatedAt,
                FinishedAt = game.FinishedAt,
                FinishLineSize = game.FinishLineSize
            };
            return response;
        }
        
        public GameEntity MapToEntity(GameCreateDto dto)
        {
            var entity = new GameEntity
            {
                Size = dto.Size,
                FinishLineSize = dto.FinishLineSize
            };
            return entity;
        }
    }
}
