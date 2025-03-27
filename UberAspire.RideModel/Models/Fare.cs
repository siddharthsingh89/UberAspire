using System.Runtime.InteropServices;

namespace UberAspire.RideModel.Models
{    
    public class Fare : EntityBase
    {
        public string RiderId { get; private set; }      
        public decimal Amount { get; private set; }
        public string Source { get; private set; }
        public string Destination { get; private set; }
        public DateTimeOffset EstimatedTimeOfArrival { get; private set; }

        private Fare()
        {
            Source = string.Empty;
            Destination = string.Empty;
            Amount = 0;
            EstimatedTimeOfArrival = DateTimeOffset.MinValue;            
        }


        private Fare(string riderId, decimal amount, string source, string destination, DateTimeOffset eta)
        {
            RiderId = riderId;
            Amount = amount;
            Source = source;
            Destination = destination;
            EstimatedTimeOfArrival = eta;
        }
        public static Fare Create(string riderId, decimal amount, string source, string destination, DateTimeOffset eta)
        {
            ValidateInputs(riderId, amount, source, destination, eta);
            return new Fare(riderId, amount, source, destination, eta);
        }

        public  void Update(string riderId, decimal amount, string source, string destination, DateTimeOffset eta)
        {
            ValidateInputs(riderId, amount, source, destination, eta);
            UpdateLastModified();

        }

        private static void ValidateInputs(string riderId, decimal amount, string source, string destination, DateTimeOffset eta)
        {

        }


    }
}
