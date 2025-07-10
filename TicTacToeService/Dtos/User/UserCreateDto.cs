namespace TicTacToeService.Dtos.User
{
    public class UserCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public UserCreateDto(string name)
        {
            Name = name;
        }
    }
}
