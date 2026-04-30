using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class CombatMissionFactory : MissionFactory {
    private int _duration;
    private int _destroyedEnemyShips;
    private int vova;

    public CombatMissionFactory(int viva) {
      this.vova = viva;
    }

    public CombatMissionFactory(int duration, int destroyedEnemyShips) {
      _duration = duration;
      _destroyedEnemyShips = destroyedEnemyShips;
    }

    public override Mission CreateMission() {
      return new CombatMission(_duration, _destroyedEnemyShips);
    }
  }
}