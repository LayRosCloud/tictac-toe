using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using TicTacToeService.Controllers;
using TicTacToeService.Dtos.Game;
using TicTacToeService.Entities;
using TicTacToeService.Tests.Common;
using TicTacToeService.Tests.Utils;

namespace TicTacToeService.Tests.Controllers
{
    public class GameControllerTest : TestCommandBase
    {
        private readonly GameController _gameController;

        public GameControllerTest()
        {
            _gameController = new GameController(Context);
        }

        [Fact]
        public async Task FindAllGamesByLimitAndPage_1_Successful()
        {
            // Arrange

            // Act
            var result = await _gameController.FindAllGames(5, 0);

            // Arrange
            Assert.IsType<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            var games = okResult.Value as IEnumerable<GameResponseDto>;
            Assert.NotNull(games);
            Assert.True(games.Any());
        }

        [Fact]
        public async Task FindAllGamesByLimitAndPage_2_Successful()
        {
            // Arrange

            // Act
            var result = await _gameController.FindAllGames(5, 1);

            // Arrange
            Assert.IsType<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            var games = okResult.Value as IEnumerable<GameResponseDto>;
            Assert.NotNull(games);
            Assert.True(games.Any());
        }

        [Fact]
        public void Health_200Status_Success()
        {
            // Arrange

            // Act
            var result = _gameController.GetHealthStatus();

            // Arrange
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Invite_Success()
        {
            // Arrange
            var resultGames = await _gameController.FindAllGames(1, 0);
            var result = (Assert.IsType<OkObjectResult>(resultGames.Result).Value as IEnumerable<GameResponseDto>).ToList()[0];

            // Act
            var gameInvite = await _gameController.AgreeInvite(new GameInviteDto { Id = result.Id, Username = StringUtils.GenerateString(10)});

            // Arrange
            var okResult = Assert.IsType<OkObjectResult>(gameInvite.Result);
        }
    }
}
