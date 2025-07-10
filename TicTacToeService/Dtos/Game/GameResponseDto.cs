namespace TicTacToeService.Dtos.Game
{
    public class GameResponseDto
    {
        public Guid Id { get; set; }

        public int CurrentStage { get; set; }

        public int Size { get; set; }

        public int FinishLineSize { get; set; }

        public long CreatedAt { get; set; }

        public long FinishedAt { get; set; }
    }
}
