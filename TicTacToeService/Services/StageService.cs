using Microsoft.EntityFrameworkCore;
using TicTacToeService.Dtos.Stage;
using TicTacToeService.Entities;
using TicTacToeService.Mappers;
using TicTacToeService.Repositories;
using TicTacToeService.Repositories.Interfaces;
using TicTacToeService.Utils.Data;
using TicTacToeService.Utils.Exceptions;

namespace TicTacToeService.Services
{
    public class StageService
    {
        private readonly IStageRepository _stageRepository;
        private readonly ParticipantService _participantService;
        private readonly GameService _gameService;
        private readonly StageMapper _stageMapper;
        private readonly DatabaseContext _database;

        public StageService(DatabaseContext context, StageMapper stageMapper) 
        {
            _stageRepository = new StageRepository(context);
            _participantService = new ParticipantService(context, new ParticipantMapper());
            _gameService = new GameService(context, new GameMapper());
            _stageMapper = stageMapper;
            _database = context;
        }

        public async Task<StageResponseDto> MakeStep(StageCreateDto dto)
        {
            var participants = await FindParticipantsAndCheckNumberNumberOfPlayers(dto);

            var duplicateStep = await _stageRepository.FindByCoordinatesXAndYAsync(dto.X, dto.Y);
            if (duplicateStep != null)
            {
                return _stageMapper.MapToResponseDto(duplicateStep, duplicateStep.Participant!);
            }

            var participant = FindParticipantMakingStepAndValidateHim(dto, participants);
            if (dto.X >= participant.Game!.Size && dto.Y >= participant.Game!.Size)
            {
                throw new BadRequestException("Error X or Y bounds of size field");
            }

            var selectedCharacter = GenerateSymbol(++participant.Game!.CurrentStage, participant.SelectedCharacter);

            var stageForCreate = new StageEntity
            {
                CoordinateX = dto.X,
                CoordinateY = dto.Y,
                ParticipantId = participant.Id,
                SuppliedSymbol = selectedCharacter
            };

            var stage = await _stageRepository.CreateAsync(stageForCreate);
            var allStages = await _stageRepository.FindAllByParticipantIds(participants.Select(x => x.Id).ToHashSet());
            allStages.Add(stage);
            
            var sizeGrid = participant.Game.Size;
            var finishLineSize = participant.Game.FinishLineSize;
            char[,] grid = GenerateGrid(sizeGrid, allStages);

            await CheckStatusGameAndSetIfPositiveConditionOnDraw(participants, participant, sizeGrid);
            
            if (IsWinningStep(selectedCharacter, finishLineSize, grid))
            {
                var participantOne = await _database.Participants.FirstAsync(x => x.Id == participant.Id);
                var participantTwo = await _database.Participants.FirstAsync(x => x.UserId != participantOne.UserId && x.GameId == participantOne.GameId);
                participantOne.Status = GameStatus.Win;
                participantTwo.Status = GameStatus.Lose;
            }
            await _database.SaveChangesAsync();
            return _stageMapper.MapToResponseDto(stage, participant);
        }

        private bool IsWinningStep(char selectedCharacter, int finishLineSize, char[,] grid)
        {
            return IsWinningDiagonalLine(grid, selectedCharacter, finishLineSize)
                            || IsWinningOppositeDiagonalLine(grid, selectedCharacter, finishLineSize)
                            || IsWinningHorizontalLine(grid, selectedCharacter, finishLineSize)
                            || IsWinningVerticalLine(grid, selectedCharacter, finishLineSize);
        }

        private async Task CheckStatusGameAndSetIfPositiveConditionOnDraw(HashSet<ParticipantEntity> participants, ParticipantEntity participant, int sizeGrid)
        {
            if (participant.Game?.CurrentStage >= sizeGrid * sizeGrid)
            {
                var participantOne = await _database.Participants.FirstAsync(x => x.Id == participant.Id);
                var participantTwo = await _database.Participants.FirstAsync(x => x.UserId != participantOne.UserId && x.GameId == participantOne.GameId);
                participantOne.Status = GameStatus.Draw;
                participantTwo.Status = GameStatus.Draw;
            }
        }

        private static ParticipantEntity FindParticipantMakingStepAndValidateHim(StageCreateDto dto, HashSet<ParticipantEntity> participants)
        {
            var participant = participants.FirstOrDefault(x => x.UserId == dto.UserId);
            if (participant == null)
            {
                throw new NotFoundException("The player is not a participant in the game");
            }
            if (participant.Status != GameStatus.Playing)
            {
                throw new BadRequestException("You not make step in the game");
            }

            return participant;
        }

        private async Task<HashSet<ParticipantEntity>> FindParticipantsAndCheckNumberNumberOfPlayers(StageCreateDto dto)
        {
            var participants = await _participantService.FindParticipantsByGameIdAsync(dto.GameId);
            if (participants.Count < 2)
            {
                throw new BadRequestException("The number of players is too small");
            }

            return participants;
        }

        private bool IsWinningDiagonalLine(char[,] grid, char character, int finishLineSize)
        {
            int countLine = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                countLine += ReturningValueIfValidSymbolInCellOnGrid(grid, character, i, i);
            }
            return countLine >= finishLineSize;
        }

        private bool IsWinningOppositeDiagonalLine(char[,] grid, char character, int finishLineSize)
        {
            int countLine = 0;
            var size = grid.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                countLine += ReturningValueIfValidSymbolInCellOnGrid(grid, character, size - i - 1 , i);
            }
            return countLine >= finishLineSize;
        }

        private bool IsWinningHorizontalLine(char[,] grid, char character, int finishLineSize)
        {
            int countLine = 0;
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    countLine += ReturningValueIfValidSymbolInCellOnGrid(grid, character, x, y);
                }

                if (countLine >= finishLineSize)
                {
                    return true;
                }
                countLine = 0;
            }
            return false;
        }

        private bool IsWinningVerticalLine(char[,] grid, char character, int finishLineSize)
        {
            int countLine = 0;
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                     countLine += ReturningValueIfValidSymbolInCellOnGrid(grid, character, x, y);
                }

                if (countLine >= finishLineSize)
                {
                    return true;
                }
                countLine = 0;
            }
            return false;
        }

        private static int ReturningValueIfValidSymbolInCellOnGrid(char[,] grid, char character, int x, int y)
        {
            return grid[x, y] == character ? 1 : 0;
        }

        private char[,] GenerateGrid(int sizeGrid, IEnumerable<StageEntity> stages)
        {
            char[,] grid = new char[sizeGrid, sizeGrid];

            foreach (var stage in stages)
            {
                grid[stage.CoordinateX, stage.CoordinateY] = stage.SuppliedSymbol;
            }
            return grid;
        }

        private char GenerateSymbol(int currentStage, char selectedCharacter)
        {
            if ((currentStage) % 3 == 0)
            {
                var random = new Random();
                var randomValue = random.Next(0, 100);
                if (randomValue < 10)
                {
                    selectedCharacter = selectedCharacter == 'x' ? 'o' : 'x';
                }
            }
            return selectedCharacter;
        }
    }
}
