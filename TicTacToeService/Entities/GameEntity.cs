using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToeService.Entities
{
    [Table("games")]
    public class GameEntity
    {
        [Key, Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("current_stage"), Required]
        public int CurrentStage { get; set; }

        [Column("size"), Required]
        public int Size { get; set; }

        [Column("finish_line_size"), Required]
        public int FinishLineSize { get; set; }

        [Column("created_at"), Required]
        public long CreatedAt { get; set; }

        [Column("finished_at"), Required]
        public long FinishedAt { get; set; }
    }
}
