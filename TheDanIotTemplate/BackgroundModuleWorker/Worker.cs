using BackgroundModuleWorker.ScopedServices;

namespace BackgroundModuleWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IScopedService _scopedService;

        public Worker(ILogger<Worker> logger, IScopedService scopedService)
        {
            _logger = logger;
            _scopedService = scopedService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await _scopedService.DoScopedWork(stoppingToken);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}