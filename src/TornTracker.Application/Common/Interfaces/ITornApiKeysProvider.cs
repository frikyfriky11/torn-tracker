namespace TornTracker.Application.Common.Interfaces;

/// <summary>
///   Represents a key provider for Torn's API
/// </summary>
public interface ITornApiKeysProvider
{
  /// <summary>
  ///   Gets the next available API Key
  /// </summary>
  /// <returns>The API Key</returns>
  public Task<string> GetNextApiKey();
}
