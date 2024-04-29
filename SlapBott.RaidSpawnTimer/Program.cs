using SlapBott.RaidSpawnTimer;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();


SlapBott.Services.Startup.ConfigureServices(builder.Services);
SlapBott.Data.Startup.ConfigureServices(builder.Services, SlapBott.RaidSpawnTimer.Properties.Resources.DbConnection);


builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(typeof(SlapBott.Core.Program).Assembly);

}); 
var host = builder.Build();
host.Run();
