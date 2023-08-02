namespace TornTracker.Application.TimeSeries;

/// <summary>
///   The request to insert a new measurement of a specific faction
/// </summary>
/// <param name="FactionId">The id of the faction</param>
[PublicAPI]
public record FactionInsertRequest(int FactionId) : IRequest<FactionInsertResponse>;

/// <summary>
///   The response to the request to insert a new measurement of a specific faction
/// </summary>
[PublicAPI]
public record FactionInsertResponse;

[UsedImplicitly]
public class FactionInsertRequestHandler : IRequestHandler<FactionInsertRequest, FactionInsertResponse>
{
  private readonly IMapper _mapper;
  private readonly ITimeSeriesDbContext _timeSeriesDbContext;
  private readonly ITornApiClient _tornApiClient;
  private readonly ITornApiKeysProvider _tornApiKeysProvider;

  public FactionInsertRequestHandler(ITornApiClient tornApiClient, ITornApiKeysProvider tornApiKeysProvider,
    ITimeSeriesDbContext timeSeriesDbContext, IMapper mapper)
  {
    _tornApiClient = tornApiClient;
    _tornApiKeysProvider = tornApiKeysProvider;
    _timeSeriesDbContext = timeSeriesDbContext;
    _mapper = mapper;
  }

  public async Task<FactionInsertResponse> Handle(FactionInsertRequest request, CancellationToken cancellationToken)
  {
    TornFaction factionData = await _tornApiClient.GetFaction(await _tornApiKeysProvider.GetNextApiKey(), request.FactionId, cancellationToken);

    Faction? faction = _mapper.Map<Faction>(factionData);

    await _timeSeriesDbContext.InsertFaction(faction, cancellationToken);

    return new FactionInsertResponse();
  }
}
