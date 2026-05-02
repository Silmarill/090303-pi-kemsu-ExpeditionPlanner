using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class CombatMissionFactory : MissionFactory {
    private readonly int _duration;
    private readonly int _destroyedEnemyShips;

    public CombatMissionFactory(int duration, int destroyedEnemyShips) {
      _duration = duration;
      _destroyedEnemyShips = destroyedEnemyShips;
    }

    public override Mission CreateMission() {
      return new CombatMission(_duration, _destroyedEnemyShips);
    }
  }
}