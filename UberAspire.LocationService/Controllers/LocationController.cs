using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UberAspire.LocationService.Models;
using UberAspire.LocationService.Services;

namespace UberAspire.LocationService.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationController : ControllerBase
{  

    private readonly ILogger<LocationController> _logger;
    private readonly ILocationService _locationService;
    public LocationController(ILogger<LocationController> logger, ILocationService locationService)
    {
        _logger = logger;
        _locationService = locationService;
}

    [HttpPost("addlocation")]
    public IActionResult AddLocation([Bind] DriverLocation driverLocation)
    {
      if(driverLocation == null || string.IsNullOrWhiteSpace(driverLocation.DriverId)
          || string.IsNullOrEmpty(driverLocation.Latitude.ToString()))
        {
            return BadRequest();
        }
        _locationService.AddLocationAsync(driverLocation);
        return Ok();
    }

    [HttpPost("getnearbydrivers")]
    public async Task<IActionResult> GetNearbyDrivers([Bind] DriverProximityRequest driverProximityRequest)
    {        
        IEnumerable<DriverLocation> result =  await _locationService.GetNearByDriversAsync(driverProximityRequest);
        return Ok(result);       
    }
}
