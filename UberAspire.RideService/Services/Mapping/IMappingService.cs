namespace UberAspire.RideService.Services.Mapping
{
    public interface IMappingService
    {
        public Task<string> GetETAForSourceAndDestination(string source, string destination);
    }
}
