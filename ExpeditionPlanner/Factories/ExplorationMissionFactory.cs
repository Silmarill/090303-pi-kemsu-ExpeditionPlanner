using System;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class ExplorationMissionFactory : MissionFactory {
    public override Mission CreateMission() {
      return new ExplorationMission();
    }
  }
}
