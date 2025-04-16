using UberAspire.RideModel.Models;
using UberAspire.RideService.ClientModels;

namespace UberAspire.RideService.Services.RideCore
{
    public interface IRideService
    {
        Task<Fare> GetFareAsync(FareInputRequest fareInputRequest);
        Task RequestRideAsync(RideRequest rideRequest);
    }
}
