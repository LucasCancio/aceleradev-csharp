using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("submission")]
    public class Submission
    {
        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Column("challenge_id")]
        public int ChallengeId { get; set; }

        [ForeignKey("ChallengeId")]
        public virtual Challenge Challenge { get; set; }

        [Column("score", TypeName = "decimal(9,2)")]
        [Required]
        public decimal Score { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime CreatedAt { get; set; }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var submission = (Submission)obj;
            return submission.ChallengeId == this.ChallengeId &&
                   submission.UserId == this.UserId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}