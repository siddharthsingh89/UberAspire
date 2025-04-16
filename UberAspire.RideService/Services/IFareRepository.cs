using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UberAspire.RideModel;
using UberAspire.RideModel.Models;
namespace UberAspire.RideService.Services
{
    public interface IFareRepository
    {      
        Task<Fare> GetFareByIdAsync(Guid fareId);
        public Task AddFareAsync(Fare fare);
        public Task UpdateFareAsync(Fare fare);
    }    
}
