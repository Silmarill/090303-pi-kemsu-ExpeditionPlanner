using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories
{
  public class ExplorationMissionFactory : MissionFactory
  {
    private int _durationDays;
    private int _newStarSystemsDiscovered;

    public ExplorationMissionFactory(int durationDays, int newStarSystemsDiscovered)
    {
      _durationDays = durationDays;
      _newStarSystemsDiscovered = newStarSystemsDiscovered;
    }

    public override Mission CreateMission()
    {
      return new ExplorationMission(_durationDays, _newStarSystemsDiscovered);
    }
  }
}
