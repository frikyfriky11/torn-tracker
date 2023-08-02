namespace TornTracker.Infrastructure.Settings;

/// <summary>
///   All the settings related to InfluxDb
/// </summary>
public sealed class InfluxDbSettings
{
  /// <summary>
  ///   The name used to bind the configuration section
  /// </summary>
  public const string ConfigurationName = "InfluxDb";

  /// <summary>
  ///   The URL of the database
  /// </summary>
  public string Url { get; set; } = default!;

  /// <summary>
  ///   The API Token generated in InfluxDb
  /// </summary>
  public string Token { get; set; } = default!;

  /// <summary>
  ///   The organization id to use
  /// </summary>
  public string OrganizationId { get; set; } = default!;

  /// <summary>
  ///   The bucket name to use
  /// </summary>
  public string Bucket { get; set; } = default!;
}
