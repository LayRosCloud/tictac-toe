using Microsoft.EntityFrameworkCore;
using TicTacToeService.Dtos.Game;
using TicTacToeService.Dtos.User;
using TicTacToeService.Entities;
using TicTacToeService.Mappers;
using TicTacToeService.Repositories;
using TicTacToeService.Repositories.Interfaces;
using TicTacToeService.Utils.Data;
using TicTacToeService.Utils.Exceptions;
using TicTacToeService.Utils.Pageable;

namespace TicTacToeService.Services;

public class GameService
{
    private readonly IGameRepository _gameRepository;
    private readonly ParticipantService _participantService;
    private readonly UserService _userService;
    private readonly GameMapper _gameMapper;
    private readonly DatabaseContext _database;
    public GameService(DatabaseContext dbContext, GameMapper gameMapper)
    {
        _database = dbContext;
        _gameRepository = new GameRepository(_database);
        _userService = new UserService(_database, new UserMapper());
        _participantService = new ParticipantService(_database, new ParticipantMapper());
        _gameMapper = gameMapper;
        
    }

    public async Task<GameEntity?> FindById(Guid id)
    {
        return await _gameRepository.FindByIdAsync(id);
    }

    public async Task<KeyValuePair<HashSet<GameResponseDto>, long>> FindAllAsync(PageableParams parameters)
    {
        var result = await _gameRepository.FindAllAsync(parameters.Limit, parameters.Offset);
        var mappedItems = _gameMapper.MapToResponseDto(result.Key);
        return new KeyValuePair<HashSet<GameResponseDto>, long>(mappedItems, result.Value);
    }

    public async Task<GameResponseDto> CreateGame(GameCreateDto dto)
    {
        var user = await FindOrCreateUserAsync(dto.Username);

        var game = _gameMapper.MapToEntity(dto);
        game.CurrentStage = 0;
        game.Id = Guid.NewGuid();
        var savedGame = await _gameRepository.CreateAsync(game);

        var participant = await _participantService.CreateParticipantForGameAsync(savedGame, user);

        await _database.SaveChangesAsync();

        return _gameMapper.MapToResponseDto(savedGame);
    }

    public async Task<GameResponseDto> InviteGame(GameInviteDto dto)
    {
        var user = await FindOrCreateUserAsync(dto.Username);

        var game = await _gameRepository.FindByIdAsync(dto.Id);

        if (game == null)
        {
            throw new NotFoundException($"Game with id {dto.Id} is not found!");
        }

        var participant = await _participantService.CreateParticipantForGameAsync(game, user);

        await _database.SaveChangesAsync();
        return _gameMapper.MapToResponseDto(game);
    }
    
    private async Task<UserEntity> FindOrCreateUserAsync(string name)
    {
        var user = await _userService.FindUserByNameAsync(name);
        if (user == null)
        {
            var createUser = new UserCreateDto(name);
            user = await _userService.CreateUserAsync(createUser);
        }
        return user;
    }
}

