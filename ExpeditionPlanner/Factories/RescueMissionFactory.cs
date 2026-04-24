using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RescueMissionFactory : MissionFactory {
    private readonly int _peopleCountToRescue;

    public RescueMissionFactory(int peopleCountToRescue) {
      _peopleCountToRescue = peopleCountToRescue;
    }

    public override Mission CreateMission() {
      return new RescueMission(_peopleCountToRescue);
    }
  }
}