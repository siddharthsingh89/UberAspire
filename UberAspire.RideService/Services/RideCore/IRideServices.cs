using UberAspire.RideModel.Models;
using UberAspire.RideService.ClientModels;

namespace UberAspire.RideService.Services.RideCore
{
    public interface IRideServices
    {
        Task<Fare> GetFareAsync(FareInputRequest fareInputRequest);
        Task<Ride> RequestRideAsync(RideRequest rideRequest);
    }
}
