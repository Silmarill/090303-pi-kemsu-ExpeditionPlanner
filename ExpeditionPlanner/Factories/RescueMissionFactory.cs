using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RescueMissionFactory : MissionFactory {
    public int PeopleCount = 50;

    public override Mission CreateMission() {
      return new RescueMission(PeopleCount);
    }
  }
}
