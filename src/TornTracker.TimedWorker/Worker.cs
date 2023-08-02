using ILogger = Serilog.ILogger;

namespace TornTracker.TimedWorker;

public class Worker : BackgroundService
{
  private readonly ILogger _logger;
  private readonly IServiceScopeFactory _serviceScopeFactory;

  public Worker(ILogger logger, IServiceScopeFactory serviceScopeFactory)
  {
    _logger = logger.ForContext<Worker>();
    _serviceScopeFactory = serviceScopeFactory;
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    using IServiceScope scope = _serviceScopeFactory.CreateScope();
    ISender mediator = scope.ServiceProvider.GetRequiredService<ISender>();
    IConfiguration configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

    int[] factionIds = configuration.GetSection("FactionIds").Get<int[]>() ?? throw new InvalidOperationException();

    PeriodicTimer timer = new(TimeSpan.FromMinutes(1));

    do
    {
      Task[] tasks = factionIds.Select(factionId => SendRequestAsync(mediator, factionId, stoppingToken)).ToArray();
      await Task.WhenAll(tasks);
    } while (await timer.WaitForNextTickAsync(stoppingToken));
  }

  private async Task SendRequestAsync(ISender mediator, int factionId, CancellationToken stoppingToken)
  {
    try
    {
      await mediator.Send(new FactionInsertRequest(factionId), stoppingToken);
    }
    catch (Exception ex)
    {
      _logger.Error(ex, "Something went wrong while requesting a new faction measurement");
    }
  }
}
