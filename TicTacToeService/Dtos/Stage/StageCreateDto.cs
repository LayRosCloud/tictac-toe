using System.ComponentModel.DataAnnotations;

namespace TicTacToeService.Dtos.Stage
{
    public class StageCreateDto
    {
        [Required]
        public Guid GameId { get; set; }
        [Required, Range(0, long.MaxValue)]
        public long UserId { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int X { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int Y { get; set; }
    }
}
