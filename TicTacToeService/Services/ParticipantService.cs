using TicTacToeService.Entities;
using TicTacToeService.Mappers;
using TicTacToeService.Repositories;
using TicTacToeService.Repositories.Interfaces;
using TicTacToeService.Utils.Data;
using TicTacToeService.Utils.Exceptions;

namespace TicTacToeService.Services
{
    public class ParticipantService
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly ParticipantMapper _participantMapper;

        public ParticipantService(DatabaseContext context, ParticipantMapper mapper)
        {
            _participantRepository = new ParticipantRepository(context);
            _participantMapper = mapper;
        }

        public async Task<HashSet<ParticipantEntity>> FindParticipantsByGameIdAsync(Guid gameId)
        {
            var items = await _participantRepository.FindAllByGameIdAsync(gameId);
            return items;
        }

        public async Task<ParticipantEntity> CreateParticipantForGameAsync(GameEntity game, UserEntity user)
        {
            var participants = await FindParticipantsByGameIdAsync(game.Id);
            ThrowBadRequestIfNotAllowedNumberPlayers(participants, user);
            var character = GenerateCharacterForPlayer(participants.Count);

            var participant = _participantMapper.MapToEntity(game, user, character);
            var item = await _participantRepository.CreateAsync(participant);
            return item;
        }

        public async Task<ParticipantEntity?> FindByGameIdAndUserIdAsync(Guid gameId, long userId)
        {
            return await _participantRepository.FindByGameIdAndUserIdAsync(gameId, userId);
        }

        private char GenerateCharacterForPlayer(int count)
        {
            char character = 'x';

            if (count == 1)
            {
                character = 'o';
            }

            return character;
        }

        private void ThrowBadRequestIfNotAllowedNumberPlayers(HashSet<ParticipantEntity> participants, UserEntity user)
        {
            var item = participants.FirstOrDefault(x => x.UserId == user.Id);
            if (IsAllowedNumberOfPlayers(participants.Count) == false || item != null)
            {
                throw new BadRequestException("There can be no more than 2 participants");
            }
        }

        private bool IsAllowedNumberOfPlayers(int count)
        {
            return count < 2;
        }
    }
}
