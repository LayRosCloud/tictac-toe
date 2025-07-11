using System;
using TicTacToeService.Mappers;
using TicTacToeService.Tests.Assertions;
using TicTacToeService.Tests.Generator;


namespace TicTacToeService.Tests.Mapper
{
    public class StageMapperTest
    {

        private readonly StageMapper _stageMapper;

        public StageMapperTest()
        {
            _stageMapper = new StageMapper(new UserMapper(), new GameMapper());
        }

        [Fact]
        public void MapUserToResponse_Successful()
        {
            //Arrange
            var participant = ParticipantGenerator.GenerateList()[0];
            var stage = StageGenerator.GenerateItem(participant);

            //Act
            var responseItem = _stageMapper.MapToResponseDto(stage, stage.Participant);

            //Assert
            StageAssert.AssertEquals(stage, responseItem);
        }
    }
}
