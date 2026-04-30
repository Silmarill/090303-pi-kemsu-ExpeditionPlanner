using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class CargoMissionFactory : MissionFactory {
    private int _duration;
    private int _deliveredTons;
    private int vova;

    public CargoMissionFactory(int viva) {
      this.vova = viva;
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