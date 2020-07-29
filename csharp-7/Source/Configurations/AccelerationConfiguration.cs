using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Codenation.Challenge.Models;

namespace Source.Configurations
{
    public class AccelerationConfiguration : IEntityTypeConfiguration<Acceleration>
    {
        public void Configure(EntityTypeBuilder<Acceleration> builder)
        {
            builder
                .HasOne(a => a.Challenge)
                .WithMany(c => c.Accelerations)
                .HasForeignKey(a => a.ChallengeId);
        }
    }
}
