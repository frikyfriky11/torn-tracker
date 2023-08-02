namespace TornTracker.Infrastructure.Services;

public class TornApiKeysProvider : ITornApiKeysProvider
{
  private readonly TornApiSettings.ApiKeyDescriptor[] _apiKeys;
  private int _currentKeyIndex;

  public TornApiKeysProvider(IOptions<TornApiSettings> settings)
  {
    _apiKeys = settings.Value.ApiKeys;
  }

  /// <inheritdoc />
  public Task<string> GetNextApiKey()
  {
    TornApiSettings.ApiKeyDescriptor descriptor = _apiKeys[_currentKeyIndex];

    // update index wrapping around to the start when it reaches the end
    _currentKeyIndex = (_currentKeyIndex + 1) % _apiKeys.Length;

    return Task.FromResult(descriptor.Key);
  }
}
