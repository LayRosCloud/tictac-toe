namespace TicTacToeService.Utils.Pageable
{
    public record PageableParams(int Limit, int Page)
    {
        public int Offset => Limit * Page - Limit;
    }
}
