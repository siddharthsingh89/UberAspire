
using UberAspire.RideModel.Persistence;
using UberAspire.RideService.Services.Fares;
using UberAspire.RideService.Services.Mapping;
using UberAspire.RideService.Services.Messaging;
using UberAspire.RideService.Services.RideCore;

namespace UberAspire.RideService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

        // Add services to the container.
        //builder.AddSqlServerDbContext<RideDbContext>(connectionName: "ridedb");
        builder.AddNpgsqlDbContext<RideDbContext>("ridedb");
        builder.AddKafkaProducer<string, string>("ridematching-queue");
        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddTransient<IFareRepository, FareRepository>();
        builder.Services.AddTransient<IRideService, CoreRideService>();
        builder.Services.AddScoped<IMappingService, AzureMappingService>();
        builder.Services.AddScoped<IPricingService, PricingService>();
        builder.Services.AddScoped<IMessagingService, KafkaQueueService>();
        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
