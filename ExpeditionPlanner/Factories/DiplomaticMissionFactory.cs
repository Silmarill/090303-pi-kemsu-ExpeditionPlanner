using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class DiplomaticMissionFactory : MissionFactory {
    public DiplomaticMissionFactory() {
    }

    public override Mission CreateMission() {
      return new DiplomaticMission();
    }
  }
}