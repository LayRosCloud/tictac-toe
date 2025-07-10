using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToeService.Entities
{
    [Table("participants")]
    public class ParticipantEntity
    {
        [Key, Required]
        [Column("id")]
        public long Id { get; set; }

        [Column("game_id"), Required]
        public Guid GameId { get; set; }

        [Column("user_id"), Required]
        public long UserId { get; set; }

        [Column("selected_character"), Required]
        public char SelectedCharacter { get; set; }
        [Column("game_status"), Required]
        public GameStatus Status { get; set; }

        public GameEntity? Game { get; set; }
        public UserEntity? User { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var participant = (ParticipantEntity)obj;
            return participant.Id.Equals(Id) &&
                participant.UserId.Equals(UserId) &&
                participant.GameId.Equals(GameId) &&
                participant.SelectedCharacter.Equals(SelectedCharacter) &&
                participant.Status.Equals(Status);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, GameId, UserId, Status, SelectedCharacter);
        }
    }
}
