using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UberAspire.RideModel.Models;

namespace UberAspire.RideModel.Persistence.Configurations
{
   public class FareConfiguration : IEntityTypeConfiguration<Fare>
    {
        public void Configure(EntityTypeBuilder<Fare> builder)
        {
            // Define table name
            builder.ToTable("Fares");

            // Set primary key
            builder.HasKey(m => m.Id);

            // Configure properties
            builder.Property(m => m.RiderId)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(m => m.Source)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(m => m.Destination)
                   .IsRequired()
                   .HasMaxLength(100);
           
            // Configure Created and LastModified properties to be
            // handled as immutable and modifiable timestamps
            builder.Property(m => m.Created)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(m => m.LastModified)
                   .IsRequired()
                   .ValueGeneratedOnUpdate();            
        }
    }
}
