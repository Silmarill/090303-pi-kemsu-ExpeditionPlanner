using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RescueMissionFactory : MissionFactory {
    public int peopleCount;

    public RescueMissionFactory(int peopleCount) {
      peopleCount = peopleCount;
    }

    public override Mission CreateMission() {
      return new RescueMission(peopleCount);
    }
  }
}