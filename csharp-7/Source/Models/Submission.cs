using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("submission")]
    public class Submission
    {
        [Required]
        [Column("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [Column("challenge_id")]
        public int ChallengeId { get; set; }
        public Challenge Challenge { get; set; }

        [Required]
        [Column("score")]
        public decimal Score { get; set; }

        [Column("created_at")]
        [Required]
        [Timestamp]
        public DateTime CreatedAt { get; set; }
    }
}
