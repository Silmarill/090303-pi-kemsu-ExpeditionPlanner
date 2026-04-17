using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RescueMissionFactory : MissionFactory {

    public override Mission CreateMission() {
      return new RescueMission(50);
    }
  }
}
