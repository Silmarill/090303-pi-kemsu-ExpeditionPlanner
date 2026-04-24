using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RescueMissionFactory : MissionFactory {
    private readonly int _rescuedCount;

    public RescueMissionFactory(int v) {
      _rescuedCount = v;
    }

    public override Mission CreateMission() {
      return new RescueMission(_rescuedCount);
    }
  }
}
