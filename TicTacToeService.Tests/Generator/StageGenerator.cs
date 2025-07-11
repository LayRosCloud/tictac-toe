using TicTacToeService.Entities;

namespace TicTacToeService.Tests.Generator
{
    public class StageGenerator
    {
        public static StageEntity GenerateItem(ParticipantEntity participant)
        {
            var random = new Random();
            return new StageEntity
            {
                Id = random.Next(0, 10000),
                Participant = participant,
                CoordinateX = random.Next(0, participant.Game.Size),
                CoordinateY = random.Next(0, participant.Game.Size),
                ParticipantId = participant.Id,
                SuppliedSymbol = participant.SelectedCharacter
            };
        }

        public static List<StageEntity> GenerateList(ParticipantEntity participant)
        {
            return new List<StageEntity>
            {
                GenerateItem(participant),
                GenerateItem(participant),
                GenerateItem(participant),
                GenerateItem(participant),
                GenerateItem(participant),
                GenerateItem(participant),
            };
        }
    }
}
