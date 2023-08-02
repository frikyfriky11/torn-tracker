namespace TornTracker.TimedWorker;

public static class Program
{
  public static int Main(string[] args)
  {
    Log.Logger = new LoggerConfiguration()
      .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
      .Enrich.FromLogContext()
      .WriteTo.Console()
      .CreateBootstrapLogger();

    try
    {
      Log.Information("Starting web host");
      CreateHostBuilder(args).Build().Run();
      return 0;
    }
    catch (Exception ex)
    {
      Log.Fatal(ex, "Host terminated unexpectedly");
      return 1;
    }
    finally
    {
      Log.CloseAndFlush();
    }
  }

  private static IHostBuilder CreateHostBuilder(string[] args)
  {
    return Host.CreateDefaultBuilder(args)
      .ConfigureServices((context, services) =>
      {
        services.AddHostedService<Worker>();
        services.AddApplicationServices();
        services.AddInfrastructureServices(context.Configuration);
      })
      .UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext());
  }
}
