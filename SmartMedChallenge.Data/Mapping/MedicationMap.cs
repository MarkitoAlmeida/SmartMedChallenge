using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartMedChallenge.Domain.Models;

namespace SmartMedChallenge.Data.Mapping
{
    public class MedicationMap : IEntityTypeConfiguration<Medication>
    {
        public void Configure(EntityTypeBuilder<Medication> builder)
        {
            builder.ToTable("Medication");
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(m => m.Quantity)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(m => m.Active)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(m => m.Excluded)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(m => m.CreationDate)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.Property(m => m.LastUpdate)
                .IsRequired()
                .HasColumnType("DateTime");
        }
    }
}
