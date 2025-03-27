namespace UberAspire.RideService.Services
{
    public interface IMappingService
    {
        public Task<string> GetETAForSourceAndDestination(string source, string destination);
    }
}
