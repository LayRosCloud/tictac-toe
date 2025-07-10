using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToeService.Dtos.User
{
    public class UserResponseDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
