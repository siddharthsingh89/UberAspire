using Microsoft.AspNetCore.Mvc;
using UberAspire.RideModel.Models;
using UberAspire.RideService.ClientModels;
using UberAspire.RideService.Services.RideCore;

namespace UberAspire.RideService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RideController : ControllerBase
    {
       
        private readonly ILogger<RideController> _logger;
        private readonly IRideService __rideService;
        public RideController(ILogger<RideController> logger,
                            IRideService rideService)
        {
            _logger = logger;
           __rideService = rideService;
        }

        [HttpPost("Fare")]
        public async Task<IActionResult> GetFare([Bind] FareInputRequest fareInputRequest)
        {           
            var fareResponse = await __rideService.GetFareAsync(fareInputRequest);
            return Ok(fareResponse);
        }


        [HttpPost]
        public async Task<IActionResult> RequestRide([Bind] RideRequest rideRequest)
        {           
           var response = __rideService.RequestRideAsync(rideRequest);           
            return Ok(response);
        }
    }
}
