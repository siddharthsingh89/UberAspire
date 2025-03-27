using Microsoft.AspNetCore.Mvc;
using UberAspire.RideModel.Models;
using UberAspire.RideService.ClientModels;
using UberAspire.RideService.Services;

namespace UberAspire.RideService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RideController : ControllerBase
    {
       
        private readonly ILogger<RideController> _logger;
        private readonly IFareRepository _fareRepository;
        private readonly IMappingService _mappingService;
        private readonly IPricingService _pricingService;
        public RideController(ILogger<RideController> logger,
                            IFareRepository fareRepository,
                            IMappingService mappingService,
                            IPricingService pricingService)
        {
            _logger = logger;
            _fareRepository = fareRepository;
            _mappingService = mappingService;
            _pricingService = pricingService;
        }

        [HttpPost("Fare")]
        public async Task<IActionResult> GetFare([Bind] FareInputRequest fareInputRequest)
        {
            if(fareInputRequest==null || string.IsNullOrWhiteSpace(fareInputRequest.PickupLocation) 
                || string.IsNullOrEmpty(fareInputRequest.Destination))
            {
                return BadRequest();
            }

            var fare = Fare.Create(
                riderId: System.Guid.NewGuid().ToString(),
                source:  fareInputRequest.PickupLocation,
                destination:  fareInputRequest.Destination,
                eta: DateTimeOffset.Now,
                amount: 10.00M                
            );
            //fix the models
           // string result = await _mappingService.GetETAForSourceAndDestination(fare.Source, fare.Destination);
            //string finalPrice = await _pricingService.GetEstimatedFare();
            await _fareRepository.AddFareAsync(fare);
            var fareFromDb = await _fareRepository.GetFareByIdAsync(fare.Id.ToString());
            return Ok(fareFromDb);
        }


        [HttpPost]
        public async Task<IActionResult> RequestRide([Bind] RideRequest rideRequest)
        {
            if (rideRequest == null || string.IsNullOrWhiteSpace(rideRequest.FareId.ToString()))
            {
                return BadRequest();
            }

            
            var fareFromDb = await _fareRepository.GetFareByIdAsync(rideRequest.FareId);
            //Call RideMatching service to get available drivers
            // This should be async polling pattern
            return Ok(fareFromDb);
        }
    }
}
