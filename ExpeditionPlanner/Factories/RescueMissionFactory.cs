using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RescueMissionFactory : MissionFactory {
    int _peoplecount;

    public RescueMissionFactory(int peoplecount) {
      _peoplecount = peoplecount;
    }
    
    public override Mission CreateMission() {
      return new RescueMission(_peoplecount);
    }
  }
}
