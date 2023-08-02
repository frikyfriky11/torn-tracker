namespace TornTracker.Application.Common.Interfaces;

/// <summary>
///   Represents a connection to a time series database that can perform storage and retrieval of time series data
/// </summary>
public interface ITimeSeriesDbContext
{
  /// <summary>
  ///   Inserts a new faction measurement along with its members
  /// </summary>
  /// <param name="faction">The faction and its members</param>
  /// <param name="cancellationToken">A cancellation token</param>
  /// <returns>Nothing</returns>
  public Task InsertFaction(Faction faction, CancellationToken cancellationToken);
}
