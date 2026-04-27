namespace ExpeditionPlanner.Factories {
    using ExpeditionPlanner.Models;

  public class CombatMissionFactory : MissionFactory {
    public override Mission CreateMission() {
      return new CombatMission();
    }
  }
}
