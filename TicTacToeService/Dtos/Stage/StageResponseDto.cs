using TicTacToeService.Dtos.Game;
using TicTacToeService.Dtos.User;

namespace TicTacToeService.Dtos.Stage
{
    public class StageResponseDto
    {
        public long Id { get; set; }
        public GameResponseDto Game { get; set; }
        public UserResponseDto User { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public char SuppliedSymbol { get; set; }
    }
}
