using Microsoft.EntityFrameworkCore;
using Source.Configurations;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Models
{
    public class CodenationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Codenation.Challenge.Models.Challenge> Challenges { get; set; }
        public DbSet<Acceleration> Accelerations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidateConfiguration());
            modelBuilder.ApplyConfiguration(new SubmissionConfiguration());
            modelBuilder.ApplyConfiguration(new AccelerationConfiguration());
        }
    }
}