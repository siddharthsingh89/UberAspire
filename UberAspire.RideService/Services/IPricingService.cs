namespace UberAspire.RideService.Services
{
    public interface IPricingService
    {
        public Task<string> GetEstimatedFare();
    }
}
