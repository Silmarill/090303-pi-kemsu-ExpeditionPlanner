using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RescueMissionFactory : MissionFactory {
    public int peopleCount = 50;
    public override Mission CreateMission() {
      return new RescueMission(peopleCount);
    }
  }
}
