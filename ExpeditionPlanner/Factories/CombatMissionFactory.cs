using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class CombatMissionFactory : MissionFactory {
    private readonly int _durationDays;
    private readonly int _enemyShipsDestroyed;

    public CombatMissionFactory(int durationDays, int enemyShipsDestroyed) {
      _durationDays = durationDays;
      _enemyShipsDestroyed = enemyShipsDestroyed;
    }

    public override Mission CreateMission() {
      return new CombatMission(_durationDays, _enemyShipsDestroyed);
    }
  }
}
