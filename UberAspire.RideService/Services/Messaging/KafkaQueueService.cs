using Confluent.Kafka;
using UberAspire.RideService.ClientModels;
using System.Text.Json;

namespace UberAspire.RideService.Services.Messaging
{
    public class KafkaQueueService : IMessagingService
    {
        private readonly ILogger<KafkaQueueService> _logger;
        private readonly IProducer<string, string> _producer;
        public KafkaQueueService(IProducer<string, string> producer, ILogger<KafkaQueueService> logger)
        {
            _logger = logger;
            _producer = producer;
        }

        public async Task AddRideRequestToQueueAsync(RideRequestMessage rideRequestMessage)
        {
            var rideObject = JsonSerializer.Serialize(rideRequestMessage);
            DeliveryResult<string,string> result = await _producer.ProduceAsync("ridequeue01", new Message<string, string>
            {
                Key = rideRequestMessage.RideId,
                Value = rideObject
            });
           
        }
    }
}
