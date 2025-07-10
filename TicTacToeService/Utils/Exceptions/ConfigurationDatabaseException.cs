namespace TicTacToeService.Utils.Exceptions
{
    public class ConfigurationDatabaseException : Exception 
    {
        public ConfigurationDatabaseException() : this("Configuration is bad configured. Please check out") { }

        public ConfigurationDatabaseException(string message) : base (message) { }
    }
}
