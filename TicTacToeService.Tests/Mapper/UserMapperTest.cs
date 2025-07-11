using TicTacToeService.Mappers;
using TicTacToeService.Tests.Assertions;
using TicTacToeService.Tests.Generator;

namespace TicTacToeService.Tests.Mapper
{
    public class UserMapperTest
    {
        private readonly UserMapper _userMapper;

        public UserMapperTest()
        {
            _userMapper = new UserMapper();
        }

        [Fact]
        public void MapUserToResponse_Successful()
        {
            //Arrange
            var user = UserGenerator.GenerateItem();

            //Act
            var responseItem = _userMapper.MapToResponseDto(user);

            //Assert
            UserAssert.AssertEquals(user, responseItem);
        }

        [Fact]
        public void MapUserToDto_Successful()
        {
            //Arrange
            var dto = UserGenerator.GenerateDto();

            //Act
            var responseItem = _userMapper.MapToEntity(dto);

            //Assert
            UserAssert.AssertEquals(responseItem, dto);
        }
    }
}
