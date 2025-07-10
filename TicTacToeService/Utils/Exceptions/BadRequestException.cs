namespace TicTacToeService.Utils.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : this("Your params is invalid. Please check out!") { }

        public BadRequestException(string message) : base(message) { }
    }
}
