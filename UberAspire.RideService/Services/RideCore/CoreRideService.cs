using UberAspire.RideModel.Models;
using UberAspire.RideService.ClientModels;
using UberAspire.RideService.Controllers;
using UberAspire.RideService.Services.Fares;
using UberAspire.RideService.Services.Mapping;
using UberAspire.RideService.Services.Messaging;
using UberAspire.RideService.Services.RideCore;

namespace UberAspire.RideService.Services.RideCore
{
    public class CoreRideService : IRideService
    {
        private readonly ILogger<RideController> _logger;
        private readonly IFareRepository _fareRepository;
        private readonly IMappingService _mappingService;
        private readonly IPricingService _pricingService;
        private readonly IMessagingService _messagingService;
        public CoreRideService(ILogger<RideController> logger,
            IFareRepository fareRepository, 
            IMappingService mappingService,
            IPricingService pricingService,
            IMessagingService messagingService)
        {
            _logger = logger;
            _fareRepository = fareRepository;
            _mappingService = mappingService;
            _pricingService = pricingService;
            _messagingService = messagingService;
        }

        public Task<Fare> GetFareAsync(FareInputRequest fareInputRequest)
        {
            throw new NotImplementedException();
        }

        public async Task RequestRideAsync(RideRequest rideRequest)
        {
            //Validate ride request
            RideRequestMessage rideRequestMessage = new RideRequestMessage();
            await _messagingService.AddRideRequestToQueueAsync(rideRequestMessage);
            //operationstatus end point
        }
    }
}
