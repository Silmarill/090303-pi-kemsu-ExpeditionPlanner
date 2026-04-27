namespace ExpeditionPlanner.Factories {
    using ExpeditionPlanner.Models;

  public class DiplomaticMissionFactory : MissionFactory {
    public override Mission CreateMission() {
      return new DiplomaticMission();
    }
  }
}
