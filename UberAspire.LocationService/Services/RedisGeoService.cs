using System.Runtime.CompilerServices;
using UberAspire.LocationService.Models;
using StackExchange.Redis;

namespace UberAspire.LocationService.Services
{
    public class RedisGeoService : ILocationService
    {
        private readonly IDatabase _database;

        public RedisGeoService(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public async Task AddLocationAsync(DriverLocation driverLocation)
        {
            await _database.GeoAddAsync("drivers", driverLocation.Longitude, driverLocation.Latitude, driverLocation.DriverId);            
        }

        public async Task<List<DriverLocation>> GetNearByDriversAsync(DriverProximityRequest driverProximityRequest)
        {
            List<DriverLocation> driverLocations = new List<DriverLocation>();
            var results = await _database.GeoRadiusAsync("drivers", driverProximityRequest.Lon, driverProximityRequest.Lat, driverProximityRequest.Radius, GeoUnit.Kilometers);
            if(results == null || results.Length == 0)
            {
                return driverLocations;
            }

          
            foreach(var result in results)
            {
                driverLocations.Add(new DriverLocation
                {
                    DriverId = result.Member.ToString(),
                    Latitude = result.Position.Value.Latitude,
                    Longitude = result.Position.Value.Longitude
                });
            }

            return driverLocations;
        }
    }
}
