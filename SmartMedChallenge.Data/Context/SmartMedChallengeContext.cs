using Microsoft.EntityFrameworkCore;
using SmartMedChallenge.Data.Mapping;
using SmartMedChallenge.Domain.Models;

namespace SmartMedChallenge.Data.Context
{
    public class SmartMedChallengeContext : DbContext
    {
        public SmartMedChallengeContext(DbContextOptions<SmartMedChallengeContext> options) : base(options) { }
        public SmartMedChallengeContext() { }

        public DbSet<Medication> Medications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MedicationMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
