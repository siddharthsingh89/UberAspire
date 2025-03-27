
namespace UberAspire.RideService.Services
{
    public class PricingService : IPricingService
    {
        public Task<string> GetEstimatedFare()
        {
            //This will be a dummy api
            //need to check how to calculate price based on various factors
            return Task.FromResult("siddharth");
        }
    }
}
