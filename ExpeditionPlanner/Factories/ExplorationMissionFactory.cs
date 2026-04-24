using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class ExplorationMissionFactory : MissionFactory {
    private int _duration;
    private int _newStarSystems;

    public ExplorationMissionFactory(int duration, int newStarSystems) {
      _duration = duration;
      _newStarSystems = newStarSystems;
    }

    public override Mission CreateMission() {
      return new ExplorationMission(_duration, _newStarSystems);
    }
  }
}