using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class CargoMissionFactory : MissionFactory {
    private readonly int _durationDays;
    private readonly int _cargoTonsDelivered;

    public CargoMissionFactory(int durationDays, int cargoTonsDelivered) {
      _durationDays = durationDays;
      _cargoTonsDelivered = cargoTonsDelivered;
    }

    public override Mission CreateMission() {
      return new CargoMission(_durationDays, _cargoTonsDelivered);
    }
  }
}
