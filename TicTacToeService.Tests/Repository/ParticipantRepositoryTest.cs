using TicTacToeService.Repositories;
using TicTacToeService.Repositories.Interfaces;
using TicTacToeService.Tests.Common;
using TicTacToeService.Tests.Generator;

namespace TicTacToeService.Tests.Repository
{
    public class ParticipantRepositoryTest : TestCommandBase
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly IUserRepository _userRepository;
        private readonly IGameRepository _gameRepository;

        public ParticipantRepositoryTest() 
        {
            _participantRepository = new ParticipantRepository(Context);
            _userRepository = new UserRepository(Context);
            _gameRepository = new GameRepository(Context);
        }

        [Fact]
        public async Task FindByGameIdAndUserId_Success()
        {
            //Arrange
            var id = Guid.NewGuid();
            var game = GameGenerator.GenerateItem(id);
            var createdGame = await _gameRepository.CreateAsync(game);
            var user = await _userRepository.FindByIdAsync(1);
            var participant = await _participantRepository.CreateAsync(new Entities.ParticipantEntity
            {
                GameId = createdGame.Id,
                SelectedCharacter = 'x',
                UserId = user.Id,
                Status = Entities.GameStatus.Draw
            });
            Context.SaveChanges();

            //Act
            participant = await _participantRepository.FindByGameIdAndUserIdAsync(game.Id, user.Id);

            //Assert
            Assert.NotNull(participant);
        }

        [Fact]
        public async Task CreateParticipant_Success()
        {
            //Arrange
            var id = Guid.NewGuid();
            var game = GameGenerator.GenerateItem(id);
            var createdGame = await _gameRepository.CreateAsync(game);
            var user = await _userRepository.FindByIdAsync(1);

            //Act
            var participant = await _participantRepository.CreateAsync(new Entities.ParticipantEntity
            {
                GameId = createdGame.Id,
                SelectedCharacter = 'x',
                UserId = user.Id,
                Status = Entities.GameStatus.Draw
            });
            Context.SaveChanges();

            //Assert
            Assert.NotNull(participant);
        }

        [Fact]
        public async Task FindByGameId_Success()
        {
            //Arrange
            var id = Guid.NewGuid();
            var game = GameGenerator.GenerateItem(id);
            var createdGame = await _gameRepository.CreateAsync(game);
            var user = await _userRepository.FindByIdAsync(1);
            var participant = await _participantRepository.CreateAsync(new Entities.ParticipantEntity
            {
                GameId = createdGame.Id,
                SelectedCharacter = 'x',
                UserId = user.Id,
                Status = Entities.GameStatus.Draw
            });
            Context.SaveChanges();

            //Act
            var participants = await _participantRepository.FindAllByGameIdAsync(game.Id);

            //Assert
            Assert.NotEmpty(participants);
        }

        [Fact]
        public async Task RemoveParticipant_Success()
        {
            //Arrange
            var id = Guid.NewGuid();
            var game = GameGenerator.GenerateItem(id);
            var createdGame = await _gameRepository.CreateAsync(game);
            var user = await _userRepository.FindByIdAsync(1);
            var participant = await _participantRepository.CreateAsync(new Entities.ParticipantEntity
            {
                GameId = createdGame.Id,
                SelectedCharacter = 'x',
                UserId = user.Id,
                Status = Entities.GameStatus.Draw
            });
            Context.SaveChanges();
            //Act
            _participantRepository.Remove(participant);
            Context.SaveChanges();
            participant = await _participantRepository.FindByGameIdAndUserIdAsync(game.Id, user.Id);
            
            //Assert
            Assert.Null(participant);
        }
    }
}
