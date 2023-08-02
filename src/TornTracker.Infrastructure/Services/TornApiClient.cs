namespace TornTracker.Infrastructure.Services;

/// <summary>
///   An implementation of Torn's API that uses the HttpClient to query the data from the endpoint
/// </summary>
public sealed class TornApiClient : ITornApiClient
{
  private readonly HttpClient _httpClient;

  public TornApiClient(HttpClient httpClient)
  {
    _httpClient = httpClient;
  }

  /// <inheritdoc />
  public async Task<TornFaction> GetFaction(string apiKey, int factionId, CancellationToken cancellationToken)
  {
    HttpResponseMessage response = await _httpClient.GetAsync($"https://api.torn.com/faction/{factionId}?key={apiKey}", cancellationToken);

    response.EnsureSuccessStatusCode();

    string responseJson = await response.Content.ReadAsStringAsync(cancellationToken);
    TornFaction? tornFaction = JsonSerializer.Deserialize<TornFaction>(responseJson);

    return tornFaction ?? throw new InvalidOperationException();
  }
}
