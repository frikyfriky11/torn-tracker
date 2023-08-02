using TornTracker.Application.Common.TornApi;

namespace TornTracker.Application.Common.Mappings;

[UsedImplicitly]
public class FactionsProfile : Profile
{
  public FactionsProfile()
  {
    CreateMap<TornFaction, Faction>()
      .ForMember(faction => faction.Members,
        options => options.MapFrom(tornFaction =>
          tornFaction.Members.Select(member => new Member
          {
            Id = member.Key,
            Name = member.Value.Name,
            Level = member.Value.Level,
            Position = member.Value.Position,
            DaysInFaction = member.Value.DaysInFaction,
            LastActionStatus = member.Value.LastAction.Status,
            LastActionTimestamp = member.Value.LastAction.Timestamp,
            LastActionRelative = member.Value.LastAction.Relative,
            StatusDescription = member.Value.Status.Description,
            StatusDetails = member.Value.Status.Details,
            StatusState = member.Value.Status.State,
            StatusColor = member.Value.Status.Color,
            StatusUntil = member.Value.Status.Until,
          })));
  }
}
