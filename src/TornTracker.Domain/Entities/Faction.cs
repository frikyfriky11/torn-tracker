namespace TornTracker.Domain.Entities;

/// <summary>
///   Represents a Torn faction
/// </summary>
public class Faction
{
  /// <summary>
  ///   The id of the faction
  /// </summary>
  public int Id { get; set; }

  /// <summary>
  ///   The name of the faction
  /// </summary>
  public string Name { get; set; } = default!;

  /// <summary>
  ///   The tag of the faction
  /// </summary>
  public string Tag { get; set; } = default!;

  /// <summary>
  ///   The tag image of the faction
  /// </summary>
  public string TagImage { get; set; } = default!;

  /// <summary>
  ///   The player id of the leader
  /// </summary>
  public int LeaderPlayerId { get; set; }

  /// <summary>
  ///   The player id of the co-leader, can be null if there is no co-leader
  /// </summary>
  public int? CoLeaderPlayerId { get; set; }

  /// <summary>
  ///   The respect points of the faction
  /// </summary>
  public int Respect { get; set; }

  /// <summary>
  ///   The age (in days) of the faction
  /// </summary>
  public int Age { get; set; }

  /// <summary>
  ///   The maximum number of faction members that the faction can hold
  /// </summary>
  public int Capacity { get; set; }

  /// <summary>
  ///   The best chain achieved by the faction
  /// </summary>
  public int BestChain { get; set; }

  /// <summary>
  ///   The ranked warring level of the faction
  /// </summary>
  public int RankLevel { get; set; }

  /// <summary>
  ///   The ranked warring level name of the faction
  /// </summary>
  public string RankName { get; set; } = default!;

  /// <summary>
  ///   The ranked warring division of the faction
  /// </summary>
  public int RankDivision { get; set; }

  /// <summary>
  ///   The ranked warring position of the faction
  /// </summary>
  public int RankPosition { get; set; }

  /// <summary>
  ///   The ranked warring wins of the faction
  /// </summary>
  public int RankWins { get; set; }

  /// <summary>
  ///   The members of the faction
  /// </summary>
  public ICollection<Member> Members { get; set; } = default!;
}