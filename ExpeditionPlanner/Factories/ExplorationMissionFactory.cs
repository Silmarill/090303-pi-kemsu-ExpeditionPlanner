using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class ExplorationMissionFactory : MissionFactory {
    private readonly int _duration;
    private readonly int _newStarSystems;

    public ExplorationMissionFactory(int duration, int newStarSystems) {
      _duration = duration;
      _newStarSystems = newStarSystems;
    }

    public override Mission CreateMission() {
      return new ExplorationMission(_duration, _newStarSystems);
    }
  }
}