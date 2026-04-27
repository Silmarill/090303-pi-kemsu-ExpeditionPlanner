namespace ExpeditionPlanner.Factories {
    using ExpeditionPlanner.Models;

  public class RescueMissionFactory : MissionFactory {
    int _peopleCount;

    public RescueMissionFactory(int peopleCount) {
      _peopleCount = peopleCount;
    }

    public override Mission CreateMission() {
      return new RescueMission(_peopleCount);
    }
  }
}
