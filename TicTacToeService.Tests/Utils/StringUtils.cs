namespace TicTacToeService.Tests.Utils
{
    public class StringUtils
    {
        public static string GenerateString(int length)
        {
            var random = new Random();
            char[] letters = new char[length];
            for (int i = 0; i < length; i++)
            {
                letters[i] = (char)random.Next('A', 'z');
            }

            return new string(letters);
        }
    }
}
