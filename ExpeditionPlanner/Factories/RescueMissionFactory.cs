using System;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RescueMissionFactory : MissionFactory {
    public RescueMissionFactory(int v) {
    }

    public override Mission CreateMission() {
      return new RescueMission();
    }
  }
}
