namespace TicTacToeService.Utils.Time
{
    public class TimeUtils
    {
        public static long GetTimeFromUtc()
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long ms = (long)(DateTime.UtcNow - epoch).TotalMilliseconds;
            long result = ms / 1000;
            return result;
        }
    }
}
