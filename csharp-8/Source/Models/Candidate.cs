using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("candidate")]
    public class Candidate
    {
        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Column("acceleration_id")]
        public int AccelerationId { get; set; }

        [ForeignKey("AccelerationId")]
        public virtual Acceleration Acceleration { get; set; }

        [Column("company_id")]
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        [Column("status")]
        [Required]
        public int Status { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime CreatedAt { get; set; }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var candidate = (Candidate)obj;
            return candidate.UserId == this.UserId && 
                   candidate.AccelerationId == this.AccelerationId && 
                   candidate.CompanyId == this.CompanyId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}