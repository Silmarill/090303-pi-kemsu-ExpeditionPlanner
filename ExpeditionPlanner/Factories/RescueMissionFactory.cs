using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RescueMissionFactory : MissionFactory {
    private int _peopleCount;

    public RescueMissionFactory(int peopleCount) {
      _peopleCount = peopleCount;
    }

    public override Mission CreateMission() {
      return new RescueMission(_peopleCount);
    }
  }
}
