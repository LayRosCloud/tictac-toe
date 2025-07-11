using System.Text;
using TicTacToeService.Dtos.User;
using TicTacToeService.Entities;
using TicTacToeService.Tests.Utils;

namespace TicTacToeService.Tests.Generator
{
    public class UserGenerator
    {
        public const string NAME_BOB = "Bob";
        public const string NAME_JOHN = "John";
        public const string NAME_DONATELLO = "Donatello";
        public const string NAME_SERGEY = "Sergey";
        public const string NAME_VADIM = "Vadim";

        public static List<UserEntity> GenerateList()
        {
            var set = new List<UserEntity>
            {
               new UserEntity { Id = 1, Name = NAME_BOB },
               new UserEntity { Id = 2, Name = NAME_JOHN },
               new UserEntity { Id = 3, Name = NAME_DONATELLO },
               new UserEntity { Id = 4, Name = NAME_SERGEY },
               new UserEntity { Id = 5, Name = NAME_VADIM },
               new UserEntity { Id = 6, Name = "Vika" },
               new UserEntity { Id = 7, Name = "Nika" },
               new UserEntity { Id = 8, Name = "Killer3000" },
               new UserEntity { Id = 9, Name = "Betrayal" },
               new UserEntity { Id = 10, Name = "lluxweet" },
            };
            return set;
        }

        public static UserEntity GenerateItem()
        {
            Random random = new Random();
            var item = new UserEntity()
            {
                Id = random.Next(1, 1000),
                Name = StringUtils.GenerateString(10)
            };
            return item;
        }

        public static UserCreateDto GenerateDto()
        {
            var item = new UserCreateDto("my_name");
            return item;
        }

    }
}
