namespace UberAspire.RideModel.Models
{
    public class Vehicle : EntityBase
    {        
        public string RegistrationNumber { get; private set; }

        public string ModelName { get; private set; }

        public string Color { get; private set; }

        public string DriverId { get; private set; }
    }
}
