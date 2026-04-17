using ExpeditionPlanner.Models;
using System;

namespace ExpeditionPlanner.Factories {
  public class RescueMissionFactory : MissionFactory {

    public override Mission CreateMission() {
      return new RescueMission(50);
    }
  }
}
