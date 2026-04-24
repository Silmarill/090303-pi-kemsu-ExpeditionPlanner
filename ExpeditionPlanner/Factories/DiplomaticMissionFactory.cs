using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class DiplomaticMissionFactory : MissionFactory {
    public override Mission CreateMission() {
      return new DiplomaticMission();
    }
  }
}
