using System.Text.Json.Serialization;

namespace UberAspire.RideService.ClientModels
{
        public class FareInputRequest
        {
            [JsonPropertyName("pickupLocation")]
            public string PickupLocation { get; set; }

            [JsonPropertyName("destination")]
            public string Destination { get; set; }
    }
}
