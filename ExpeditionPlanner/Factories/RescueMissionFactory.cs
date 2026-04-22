using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RescueMissionFactory(int peopleCount) : MissionFactory {
    private readonly int _peopleCount = peopleCount;

    public override Mission CreateMission() {
      return new RescueMission(_peopleCount);
    }
  }
}