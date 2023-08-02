namespace TornTracker.Domain.Entities;

/// <summary>
///   Represents a Torn member of a faction
/// </summary>
public class Member
{
  /// <summary>
  ///   The player id
  /// </summary>
  public int Id { get; set; }

  /// <summary>
  ///   The name of the player
  /// </summary>
  public string Name { get; set; } = default!;

  /// <summary>
  ///   The level of the player
  /// </summary>
  public int Level { get; set; }

  /// <summary>
  ///   The number of days this player has been in the faction
  /// </summary>
  public int DaysInFaction { get; set; }

  /// <summary>
  ///   The status of the last action of the player.
  ///   Can be Offline, Idle or Online
  /// </summary>
  public string LastActionStatus { get; set; } = default!;

  /// <summary>
  ///   The timestamp of the last action of the player
  /// </summary>
  public int LastActionTimestamp { get; set; }

  /// <summary>
  ///   The time relative to now of the last action of the player
  /// </summary>
  public string LastActionRelative { get; set; } = default!;

  /// <summary>
  ///   The description of the status of the player.
  ///   Should represent what it is doing, such as Travelling, Jail, Hospital, etc.
  /// </summary>
  public string StatusDescription { get; set; } = default!;

  /// <summary>
  ///   The details of the status of the player.
  ///   Should represent the specific cause of the status, such as Being questioned, Overdosed, etc.
  /// </summary>
  public string StatusDetails { get; set; } = default!;

  /// <summary>
  ///   The synthetic description of the status of the player
  /// </summary>
  public string StatusState { get; set; } = default!;

  /// <summary>
  ///   The color of the status of the player.
  ///   Should be green, red or blue.
  /// </summary>
  public string StatusColor { get; set; } = default!;

  /// <summary>
  ///   The timestamp until the status will be valid, or zero if the player is Okay
  /// </summary>
  public int StatusUntil { get; set; }

  /// <summary>
  ///   The position assigned to the player in the faction
  /// </summary>
  public string Position { get; set; } = default!;
}
