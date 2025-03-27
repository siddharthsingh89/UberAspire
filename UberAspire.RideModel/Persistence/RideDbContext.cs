using Microsoft.EntityFrameworkCore;
using UberAspire.RideModel.Models;

namespace UberAspire.RideModel.Persistence
{
    public class RideDbContext(DbContextOptions<RideDbContext> options) : DbContext(options)
    {
        public DbSet<Ride> Rides => Set<Ride>();
        public DbSet<Fare> Fares => Set<Fare>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("app");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RideDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
