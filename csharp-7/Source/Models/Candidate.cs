using Codenation.Challenge.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("candidate")]
    public class Candidate
    {
        [Required]
        [Column("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [Column("acceleration_id")]
        public int AccelerationId { get; set; }
        public Acceleration Acceleration { get; set; }

        [Required]
        [Column("company_id")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Required]
        [Column("status")]
        public int Status { get; set; }

        [Column("created_at")]
        [Required]
        [Timestamp]
        public DateTime CreatedAt { get; set; }
    }
}
