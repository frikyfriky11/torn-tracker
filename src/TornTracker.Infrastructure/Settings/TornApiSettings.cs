namespace TornTracker.Infrastructure.Settings;

/// <summary>
///   All the settings related to Torn's API
/// </summary>
public sealed class TornApiSettings
{
  /// <summary>
  ///   The name used to bind the configuration section
  /// </summary>
  public const string ConfigurationName = "TornApi";

  /// <summary>
  ///   The API keys to use. These will be rotated by the API Key provider service.
  /// </summary>
  public ApiKeyDescriptor[] ApiKeys { get; set; } = default!;

  /// <summary>
  ///   An API Key descriptor
  /// </summary>
  public class ApiKeyDescriptor
  {
    /// <summary>
    ///   Specifies which user the key belongs to. Not used in the application, only for documentation purposes.
    /// </summary>
    public string Username { get; set; } = default!;

    /// <summary>
    ///   The API Key value
    /// </summary>
    public string Key { get; set; } = default!;
  }
}
