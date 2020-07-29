using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("full_name")]
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Column("email")]
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Column("nickname")]
        [Required]
        [MaxLength(50)]
        public string NickName { get; set; }

        [Column("password")]
        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        [Column("created_at")]
        [Required]
        [Timestamp]
        public DateTime CreatedAt { get; set; }

        public ICollection<Candidate> Candidates { get; set; }
        public ICollection<Submission> Submissions { get; set; }
    }
}
