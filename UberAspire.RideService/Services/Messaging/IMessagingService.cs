using UberAspire.RideService.ClientModels;

namespace UberAspire.RideService.Services.Messaging
{
    public interface IMessagingService
    {
        Task AddRideRequestToQueueAsync(RideRequestMessage rideRequestMessage);
    }
}
