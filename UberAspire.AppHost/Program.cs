using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);
var postgres = builder.AddPostgres("postgres");
var postgresdb = postgres.AddDatabase("ridedb");


//var sql = builder.AddSqlServer("sql")
                // .WithLifetime(ContainerLifetime.Persistent);

//var sqldb = sql.AddDatabase("ridedb");

var locationCache = builder.AddRedis("locationstore");

var kafka = builder.AddKafka("ridematching-queue")
                    .WithKafkaUI();

var distributedLockStore = builder.AddRedis("distributedlockstore");

var migrationService = builder.AddProject<Projects.UberAspire_MigrationSerivce>("uberaspire-migrationserivce")
    .WithReference(postgresdb)
    .WaitFor(postgresdb);

var apiService = builder.AddProject<Projects.UberAspire_ApiService>("apiservice");

builder.AddProject<Projects.UberAspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

var rideService = builder.AddProject<Projects.UberAspire_RideService>("uberaspire-rideservice")
             .WithExternalHttpEndpoints()
             .WithReference(postgresdb)
             .WithReference(kafka)
             .WaitForCompletion(migrationService);

var locationService = builder.AddProject<Projects.UberAspire_LocationService>("uberaspire-locationservice")
    .WithExternalHttpEndpoints()
    .WithReference(locationCache);

var rideMatchingService = builder.AddProject<Projects.UberAspire_RideMatchingService>("uberaspire-ridematchingservice")
    .WithReference(distributedLockStore)
    .WithReference(locationService)
    .WithReference(kafka)
    .WaitFor(locationService);

builder.AddProject<Projects.UberAspire_NotificationService>("uberaspire-notificationservice");

builder.Build().Run();
