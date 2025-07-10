using Microsoft.AspNetCore.Mvc;
using TicTacToeService.Dtos.Stage;
using TicTacToeService.Services;
using TicTacToeService.Utils.Data;

namespace TicTacToeService.Controllers
{
    [ApiController]
    [Route("v1/stages")]
    public class StageController : Controller
    {
        private readonly StageService _stageService;

        public StageController(DatabaseContext context)
        {
            _stageService = new StageService(context, new Mappers.StageMapper(new Mappers.UserMapper(), new Mappers.GameMapper()));
        }

        [HttpPost("moves")]
        public async Task<ActionResult<StageResponseDto>> MakeStep([FromBody] StageCreateDto dto)
        {
            var item = await _stageService.MakeStep(dto);
            return Ok(item);
        }
    }
}
