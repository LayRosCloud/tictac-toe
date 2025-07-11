using TicTacToeService.Dtos.User;
using TicTacToeService.Entities;

namespace TicTacToeService.Tests.Assertions
{
    public class UserAssert
    {
        public static void AssertEquals(UserEntity user, UserResponseDto dto)
        {
            Assert.Equal(user.Id, dto.Id);
            Assert.Equal(user.Name, dto.Name);
        }

        public static void AssertEquals(UserEntity user, UserEntity user1)
        {
            Assert.Equal(user.Id, user1.Id);
            Assert.Equal(user.Name, user1.Name);
        }

        public static void AssertEquals(List<UserEntity> users, List<UserResponseDto> dtos)
        {
            Assert.Equal(users.Count, dtos.Count);
            for (int i = 0; i < users.Count; i++)
            {
                AssertEquals(users[i], dtos[i]);
            }
        }

        public static void AssertEquals(UserEntity user, UserCreateDto dto)
        {
            Assert.Equal(user.Name, dto.Name);
        }
    }
}
