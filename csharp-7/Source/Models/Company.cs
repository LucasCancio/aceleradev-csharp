using Codenation.Challenge.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("company")]
    public class Company
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column("slug")]
        [Required]
        [MaxLength(50)]
        public string Slug { get; set; }

        [Column("created_at")]
        [Required]
        [Timestamp]
        public DateTime CreatedAt { get; set; }

        public ICollection<Candidate> Candidates { get; set; }
    }
}