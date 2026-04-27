using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {

  public class CargoMissionFactory : MissionFactory {
    public override Mission CreateMission() {
      return new CargoMission();
    }
  }
}
