using TicTacToeService.Entities;

namespace TicTacToeService.Mappers
{
    public class ParticipantMapper
    {
        public ParticipantEntity MapToEntity(GameEntity game, UserEntity user, char character)
        {
            var participant = new ParticipantEntity
            {
                Game = game,
                User = user,
                SelectedCharacter = character,
                Status = GameStatus.Playing
            };
            return participant;
        }
    }
}
