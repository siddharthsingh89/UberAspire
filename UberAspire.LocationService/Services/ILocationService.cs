using UberAspire.LocationService.Models;

namespace UberAspire.LocationService.Services
{
    public interface ILocationService
    {
        public Task AddLocationAsync(DriverLocation driverLocation);
        public Task<List<DriverLocation>> GetNearByDriversAsync(DriverProximityRequest driverProximityRequest);
    }
}
