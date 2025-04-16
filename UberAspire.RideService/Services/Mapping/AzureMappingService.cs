using Azure;
using Azure.Maps.Routing;
using Azure.Core.GeoJson;
using Azure.Maps.Routing.Models;

namespace UberAspire.RideService.Services.Mapping
{
    public class AzureMappingService : IMappingService
    {
        public Task<string> GetETAForSourceAndDestination(string source, string destination)
        {
            // Create a MapsRoutingClient that will authenticate through Subscription Key (Shared key)
            AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
            MapsRoutingClient client = new MapsRoutingClient(credential);

            //Convert the source and destination to Geocodes

            // Create origin and destination routing points
            List<GeoPosition> routePoints = new List<GeoPosition>()
            {
                new GeoPosition(123.751, 45.9375),
                new GeoPosition(123.791, 45.96875)
            };

            RouteDirectionOptions options = new RouteDirectionOptions()
            {
                RouteType = RouteType.Fastest,
                UseTrafficData = true,
                TravelMode = TravelMode.Bicycle,
                Language = RoutingLanguage.EnglishUsa,
            };

            // Create Route direction query object
            RouteDirectionQuery query = new RouteDirectionQuery(routePoints);
            Response<RouteDirections> result = client.GetDirections(query);

            // Route direction result
            Console.WriteLine($"Total {0} route results", result.Value.Routes.Count);
            Console.WriteLine(result.Value.Routes[0].Summary.LengthInMeters);
            Console.WriteLine(result.Value.Routes[0].Summary.TravelTimeDuration);

            // Route points
            foreach (RouteLeg leg in result.Value.Routes[0].Legs)
            {
                Console.WriteLine("Route path:");
                foreach (GeoPosition point in leg.Points)
                {
                    Console.WriteLine($"point({point.Latitude}, {point.Longitude})");
                }
            }

            return Task.FromResult(result.Value.Routes[0].Summary.TravelTimeDuration.ToString());
        }
    }
}
