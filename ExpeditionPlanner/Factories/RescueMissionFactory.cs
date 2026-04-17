using System;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RescueMissionFactory : MissionFactory {
    int _peopleCount;
    public RescueMissionFactory(int peopleCount) {
      _peopleCount = peopleCount;
    }
    public override Mission CreateMission() {
      return new RescueMission (_peopleCount);
    }
  }
}