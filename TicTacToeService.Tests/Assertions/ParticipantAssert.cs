using TicTacToeService.Entities;

namespace TicTacToeService.Tests.Assertions
{
    public class ParticipantAssert
    {
        public static void AssertEquals(ParticipantEntity participant, GameEntity game, UserEntity user, char character)
        {
            Assert.Equal(participant.SelectedCharacter, character);
            Assert.Equal(GameStatus.Playing, participant.Status);
            GameAssert.AssertEquals(participant?.Game!, game);
            UserAssert.AssertEquals(participant?.User!, user);
        }
    }
}
