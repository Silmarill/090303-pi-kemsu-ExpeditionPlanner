namespace ExpeditionPlanner.Factories {
    using ExpeditionPlanner.Models;

  public class ExplorationMissionFactory : MissionFactory {
    public override Mission CreateMission() {
      return new ExplorationMission();
    }
  }
}
