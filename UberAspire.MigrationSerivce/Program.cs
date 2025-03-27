using Microsoft.EntityFrameworkCore;
using UberAspire.MigrationService;
using UberAspire.RideModel.Persistence;

namespace UberAspire.MigrationService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.AddServiceDefaults();
        builder.Services.AddHostedService<Worker>();

        builder.Services.AddOpenTelemetry()
            .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));
        //builder.AddNpgsqlDbContext<RideDbContext>(connectionName: "postgresdb");

        builder.Services.AddDbContextPool<RideDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ridedb"), sqlOptions => {
            sqlOptions.MigrationsAssembly("UberAspire.MigrationSerivce");
            sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    null
                );
            }
    )
);
        var host = builder.Build();
        host.Run();
    }
}