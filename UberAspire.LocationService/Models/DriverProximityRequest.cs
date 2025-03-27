using Microsoft.AspNetCore.Mvc;

namespace UberAspire.LocationService.Models
{
    public class DriverProximityRequest
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
        public double Radius { get; set; }
        public string Unit { get; set; }
    }
}
