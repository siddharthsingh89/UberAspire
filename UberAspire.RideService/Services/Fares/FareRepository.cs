using Microsoft.EntityFrameworkCore;
using UberAspire.RideModel.Models;
using UberAspire.RideModel.Persistence;

namespace UberAspire.RideService.Services.Fares
{
    public class FareRepository : IFareRepository
    {
        private readonly RideDbContext _context;

        public FareRepository(RideDbContext context)
        {
            _context = context;
        }       

        public async Task<Fare> GetFareByIdAsync(Guid fareId)
        {
            return await _context.Fares.FindAsync(fareId);
        }

        public async Task AddFareAsync(Fare fare)
        {
            await _context.Fares.AddAsync(fare);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFareAsync(Fare fare)
        {
            _context.Fares.Update(fare);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFareAsync(string fareId)
        {
            var fare = await _context.Fares.FindAsync(fareId);
            if (fare != null)
            {
                _context.Fares.Remove(fare);
                await _context.SaveChangesAsync();
            }
        }
        
    }
}
