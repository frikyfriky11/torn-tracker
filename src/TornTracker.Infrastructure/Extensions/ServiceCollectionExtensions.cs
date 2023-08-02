namespace TornTracker.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
  /// <summary>
  ///   Adds the infrastructure services to the Dependency Injection container.
  /// </summary>
  /// <param name="services">The service collection container</param>
  /// <param name="configuration">The configuration object</param>
  /// <param name="webHostEnvironment">The web host environment object</param>
  public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
  {
    // add all the settings
    // see https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-7.0#bind-hierarchical-configuration for help
    services.Configure<InfluxDbSettings>(configuration.GetSection(InfluxDbSettings.ConfigurationName));
    services.Configure<TornApiSettings>(configuration.GetSection(TornApiSettings.ConfigurationName));

    // add the time series database
    services.AddScoped<IInfluxDBClient>(serviceProvider =>
    {
      IOptionsMonitor<InfluxDbSettings> optionsMonitor = serviceProvider.GetRequiredService<IOptionsMonitor<InfluxDbSettings>>();

      return new InfluxDBClient(new InfluxDBClientOptions(optionsMonitor.CurrentValue.Url)
      {
        Bucket = optionsMonitor.CurrentValue.Bucket,
        Org = optionsMonitor.CurrentValue.OrganizationId,
        Token = optionsMonitor.CurrentValue.Token,
      });
    });

    // add the service implementations
    services.AddSingleton<IClock>(SystemClock.Instance);
    services.AddHttpClient<ITornApiClient, TornApiClient>();
    services.AddScoped<ITimeSeriesDbContext, InfluxDbContext>();
    services.AddSingleton<ITornApiKeysProvider, TornApiKeysProvider>();
  }
}
