namespace UberAspire.RideService.Services.Fares
{
    public interface IPricingService
    {
        public Task<string> GetEstimatedFare();
    }
}
