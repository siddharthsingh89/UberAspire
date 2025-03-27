using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UberAspire.RideModel.Models;

namespace UberAspire.RideService.Persistence.Configurations
{
  public class RideConfiguration : IEntityTypeConfiguration<Ride>
    {
        public void Configure(EntityTypeBuilder<Ride> builder)
        {
            // Define table name
            builder.ToTable("Rides");

            // Set primary key
            builder.HasKey(m => m.Id);

            // Configure properties
            builder.Property(m => m.FareId)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(m => m.Source)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(m => m.Destination)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(m => m.Status)
                   .IsRequired();           

            // Configure Created and LastModified properties to be handled as immutable and modifiable timestamps
            builder.Property(m => m.Created)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(m => m.LastModified)
                   .IsRequired()
                   .ValueGeneratedOnUpdate();            
        }
    }
}
