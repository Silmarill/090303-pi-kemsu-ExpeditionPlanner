namespace ExpeditionPlanner.Factories {
    using ExpeditionPlanner.Models;

  public class CargoMissionFactory : MissionFactory {
    public override Mission CreateMission() {
      return new CargoMission();
    }
  }
}
