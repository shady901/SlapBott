
using MediatR;

namespace SlapBott.RaidSpawnTimer
{
    public class Worker(ILogger<Worker> logger, IMediator mediator) : BackgroundService
    {
        private readonly ILogger<Worker> _logger = logger;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("TimerCheck");

                var d = await mediator.Send(new SlapBott.Requests.GetRegistration(10));

                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }
    }
}
