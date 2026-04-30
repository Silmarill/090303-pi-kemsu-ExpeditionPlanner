using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class CargoMissionFactory : MissionFactory {
    private readonly int _duration;
    private readonly int _deliveredTons;

    public CargoMissionFactory(int v) {
    }

    public CargoMissionFactory(int duration, int deliveredTons) {
      _duration = duration;
      _deliveredTons = deliveredTons;
    }

    public override Mission CreateMission() {
      return new CargoMission(_duration, _deliveredTons);
    }
  }
}