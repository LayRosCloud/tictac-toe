using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToeService.Entities
{
    [Table("users")]
    public class UserEntity
    {
        [Key, Required]
        [Column("id")]
        public long Id { get; set; }

        [Column("name"), Required]
        public string Name { get; set; } = string.Empty;
    }
}
