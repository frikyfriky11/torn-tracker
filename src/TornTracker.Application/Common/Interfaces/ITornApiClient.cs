namespace TornTracker.Application.Common.Interfaces;

/// <summary>
///   Represents a client that can query Torn's API
/// </summary>
public interface ITornApiClient
{
  /// <summary>
  ///   Gets a faction data with the specified id along with its members
  /// </summary>
  /// <param name="apiKey">The API key to use</param>
  /// <param name="factionId">The id of the faction to retrieve</param>
  /// <param name="cancellationToken">A cancellation token</param>
  /// <returns>The raw faction data along with its members</returns>
  public Task<TornFaction> GetFaction(string apiKey, int factionId, CancellationToken cancellationToken);
}
