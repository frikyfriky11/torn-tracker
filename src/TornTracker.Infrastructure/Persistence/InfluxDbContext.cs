namespace TornTracker.Infrastructure.Persistence;

/// <summary>
///   An implementation of the time series database that uses InfluxDb as a backing store
/// </summary>
public class InfluxDbContext : ITimeSeriesDbContext
{
  private readonly IClock _clock;
  private readonly IInfluxDBClient _influxDbClient;

  public InfluxDbContext(IInfluxDBClient influxDbClient, IClock clock)
  {
    _influxDbClient = influxDbClient;
    _clock = clock;
  }

  /// <inheritdoc />
  public Task InsertFaction(Faction faction, CancellationToken cancellationToken)
  {
    IWriteApi? writeApi = _influxDbClient.GetWriteApi();

    List<PointData> points = new();

    PointData? factionMeasurement = PointData.Measurement("faction")
      .Tag("id", faction.Id.ToString())
      .Tag("name", faction.Name)
      .Tag("tag", faction.Tag)
      .Field("tag_image", faction.TagImage)
      .Field("leader_player_id", faction.LeaderPlayerId.ToString())
      .Field("co_leader_player_id", faction.CoLeaderPlayerId.ToString())
      .Field("respect", faction.Respect)
      .Field("age", faction.Age)
      .Field("capacity", faction.Capacity)
      .Field("best_chain", faction.BestChain)
      .Field("rank_level", faction.RankLevel)
      .Field("rank_name", faction.RankName)
      .Field("rank_division", faction.RankDivision)
      .Field("rank_position", faction.RankPosition)
      .Field("rank_wins", faction.RankWins)
      .Timestamp(_clock.GetCurrentInstant(), WritePrecision.Ms);

    points.Add(factionMeasurement);

    foreach (Member factionMember in faction.Members)
    {
      PointData? memberMeasurement = PointData.Measurement("member")
        .Tag("id", factionMember.Id.ToString())
        .Tag("name", factionMember.Name)
        .Tag("faction_id", faction.Id.ToString())
        .Field("name", factionMember.Level)
        .Field("days_in_faction", factionMember.DaysInFaction)
        .Field("last_action_status", factionMember.LastActionStatus)
        .Field("last_action_timestamp", factionMember.LastActionTimestamp)
        .Field("last_action_relative", factionMember.LastActionRelative)
        .Field("status_description", factionMember.StatusDescription)
        .Field("status_details", factionMember.StatusDetails)
        .Field("status_state", factionMember.StatusState)
        .Field("status_color", factionMember.StatusColor)
        .Field("status_until", factionMember.StatusUntil)
        .Field("position", factionMember.Position)
        .Timestamp(_clock.GetCurrentInstant(), WritePrecision.Ms);

      points.Add(memberMeasurement);
    }

    writeApi.WritePoints(points);

    return Task.CompletedTask;
  }
}
