// ReSharper disable InconsistentNaming

namespace TornTracker.Application.Common.TornApi;

[PublicAPI]
public record TornFaction
{
  [JsonPropertyName("ID")]
  public int Id { get; init; }

  [JsonPropertyName("name")]
  public string Name { get; init; } = default!;

  [JsonPropertyName("tag")]
  public string Tag { get; init; } = default!;

  [JsonPropertyName("tag_image")]
  public string TagImage { get; init; } = default!;

  [JsonPropertyName("leader")]
  public int LeaderPlayerId { get; init; }

  [JsonPropertyName("co-leader")]
  public int CoLeaderPlayerId { get; init; }

  [JsonPropertyName("respect")]
  public int Respect { get; init; }

  [JsonPropertyName("age")]
  public int Age { get; init; }

  [JsonPropertyName("capacity")]
  public int Capacity { get; init; }

  [JsonPropertyName("best_chain")]
  public int BestChain { get; init; }

  [JsonPropertyName("rank")]
  public TornFactionRank Rank { get; init; } = default!;

  [JsonPropertyName("members")]
  public IDictionary<int, TornFactionMember> Members { get; init; } = default!;
}

[PublicAPI]
public record TornFactionRank
{
  [JsonPropertyName("level")]
  public int Level { get; init; }

  [JsonPropertyName("name")]
  public string Name { get; init; } = default!;

  [JsonPropertyName("division")]
  public int Division { get; init; }

  [JsonPropertyName("position")]
  public int Position { get; init; }

  [JsonPropertyName("wins")]
  public int Wins { get; init; }
}

[PublicAPI]
public record TornFactionMember
{
  [JsonPropertyName("name")]
  public string Name { get; init; } = default!;

  [JsonPropertyName("level")]
  public int Level { get; init; }

  [JsonPropertyName("days_in_faction")]
  public int DaysInFaction { get; init; }

  [JsonPropertyName("last_action")]
  public TornFactionMemberLastAction LastAction { get; init; } = default!;

  [JsonPropertyName("status")]
  public TornFactionMemberStatus Status { get; init; } = default!;

  [JsonPropertyName("position")]
  public string Position { get; init; } = default!;
}

[PublicAPI]
public record TornFactionMemberLastAction
{
  [JsonPropertyName("status")]
  public string Status { get; init; } = default!;

  [JsonPropertyName("timestamp")]
  public int Timestamp { get; init; }

  [JsonPropertyName("relative")]
  public string Relative { get; init; } = default!;
}

[PublicAPI]
public record TornFactionMemberStatus
{
  [JsonPropertyName("description")]
  public string Description { get; init; } = default!;

  [JsonPropertyName("details")]
  public string Details { get; init; } = default!;

  [JsonPropertyName("state")]
  public string State { get; init; } = default!;

  [JsonPropertyName("color")]
  public string Color { get; init; } = default!;

  [JsonPropertyName("until")]
  public int Until { get; init; }
}
