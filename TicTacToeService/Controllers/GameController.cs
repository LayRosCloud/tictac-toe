using Microsoft.AspNetCore.Mvc;
using TicTacToeService.Dtos.Game;
using TicTacToeService.Services;
using TicTacToeService.Utils.Data;
using TicTacToeService.Utils.Pageable;

namespace TicTacToeService.Controllers
{
    [ApiController]
    [Route("v1/games")]
    public class GameController : ControllerBase
    {
        private readonly GameService _service;

        public GameController(DatabaseContext context)
        {
            _service = new GameService(context, new Mappers.GameMapper());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameResponseDto>>> FindAllGames(int limit, int page)
        {
            var result = await _service.FindAllAsync(new PageableParams(limit, page));
            HttpContext.Response.Headers.Append("x-total-count", result.Value.ToString());
            return Ok(result.Key);
        }

        [HttpPost("invite")]
        public async Task<ActionResult<GameResponseDto>> AgreeInvite([FromBody] GameInviteDto dto)
        {
            var game = await _service.InviteGame(dto);
            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<GameResponseDto>> CreateGame([FromBody] GameCreateDto dto)
        {
            var game = await _service.CreateGame(dto);
            HttpContext.Response.StatusCode = StatusCodes.Status201Created;
            return Created("v1/games", game);
        }
    }
}
