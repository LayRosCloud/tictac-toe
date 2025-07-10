using System.ComponentModel.DataAnnotations;

namespace TicTacToeService.Dtos.Game
{
    public class GameInviteDto
    {
        [Required]
        public Guid Id { get; set; } = Guid.Empty;
        [Required, Length(3, 100)]
        public string Username { get; set; } = string.Empty;
    }
}
