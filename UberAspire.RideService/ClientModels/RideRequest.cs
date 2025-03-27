using System.Text.Json.Serialization;

namespace UberAspire.RideService.ClientModels
{
    public class RideRequest
    {
        [JsonPropertyName("fareId")]
        public string FareId { get; set; }      
    }
}
