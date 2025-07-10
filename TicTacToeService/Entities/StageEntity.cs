using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToeService.Entities
{
    [Table("stages")]
    public class StageEntity
    {
        [Key, Required]
        [Column("id")]
        public long Id { get; set; }

        [Column("participant_id"), Required]
        public long ParticipantId { get; set; }
        [Column("x"), Required]
        public int CoordinateX { get; set; }
        [Column("y"), Required]
        public int CoordinateY { get; set; }

        [Column("supplied_symbol"), Required]
        public char SuppliedSymbol { get; set; }

        public ParticipantEntity? Participant { get; set; }
    }
}
