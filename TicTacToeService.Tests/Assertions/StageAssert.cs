using TicTacToeService.Dtos.Stage;
using TicTacToeService.Entities;

namespace TicTacToeService.Tests.Assertions
{
    public class StageAssert
    {
        public static void AssertEquals(StageEntity stage, StageResponseDto dto)
        {
            Assert.Equal(stage.Id, dto.Id);
            Assert.Equal(stage.CoordinateY, dto.CoordinateY);
            Assert.Equal(stage.CoordinateX, dto.CoordinateX);
            Assert.Equal(stage.SuppliedSymbol, dto.SuppliedSymbol);
        }
    }
}
