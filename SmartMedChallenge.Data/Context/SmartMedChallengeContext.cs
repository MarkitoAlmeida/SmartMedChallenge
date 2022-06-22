using Microsoft.EntityFrameworkCore;
using SmartMedChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedChallenge.Data.Context
{
    public class SmartMedChallengeContext : DbContext
    {
        public SmartMedChallengeContext(DbContextOptions<SmartMedChallengeContext> options) : base(options) { }
        public SmartMedChallengeContext() { }

        public DbSet<Medication> Medications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add mapping

            base.OnModelCreating(modelBuilder);
        }
    }
}
