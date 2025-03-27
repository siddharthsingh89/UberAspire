namespace UberAspire.RideModel.Models
{
    public class Ride : EntityBase
    {        
        public string RiderId { get; private set; }
        public string FareId { get; private set; }
        public string DriverId { get; private set; }
        public string Destination { get; private set; }
        public string Source { get; private set; }
        public DateTimeOffset RideDate { get; private set; }       
        public RideStatus Status { get; private set; }
    }
}
