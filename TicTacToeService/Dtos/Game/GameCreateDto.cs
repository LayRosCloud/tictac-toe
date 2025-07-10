using System.ComponentModel.DataAnnotations;

namespace TicTacToeService.Dtos.Game
{
    public class GameCreateDto
    {
        [Required, Length(3, 100)]
        public string Username { get; set; } = string.Empty;
        [Required, Range(3, 32)]
        public int Size { get; set; }
        [Required, Range(3, 32)]
        public int FinishLineSize { get; set; }
    }
}
