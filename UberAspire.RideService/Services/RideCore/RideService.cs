using UberAspire.RideModel.Models;
using UberAspire.RideService.ClientModels;
using UberAspire.RideService.Controllers;
using UberAspire.RideService.Services.Fares;
using UberAspire.RideService.Services.Mapping;
using UberAspire.RideService.Services.RideCore;

namespace UberAspire.RideService.Services.RideCore
{
    public class RideService : IRideServices
    {
        private readonly ILogger<RideController> _logger;
        private readonly IFareRepository _fareRepository;
        private readonly IMappingService _mappingService;
        private readonly IPricingService _pricingService;

        public RideService(ILogger<RideController> logger, IFareRepository fareRepository, IMappingService mappingService, IPricingService pricingService)
        {
            _logger = logger;
            _fareRepository = fareRepository;
            _mappingService = mappingService;
            _pricingService = pricingService;
        }

        public Task<Fare> GetFareAsync(FareInputRequest fareInputRequest)
        {
            throw new NotImplementedException();
        }

        public Task<Ride> RequestRideAsync(RideRequest rideRequest)
        {
            throw new NotImplementedException();
        }
    }
}
