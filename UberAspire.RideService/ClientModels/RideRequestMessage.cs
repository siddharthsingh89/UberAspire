namespace UberAspire.RideService.ClientModels
{
    public class RideRequestMessage
    {
        public string RideId { get; set; }
        public string UserId { get; set; }
        public string VehicleId { get; set; }
        public double PickupLocation { get; set; }
        public double DropoffLocation { get; set; }
        public DateTime RequestTime { get; set; }
        public string Status { get; set; }
    }
}
