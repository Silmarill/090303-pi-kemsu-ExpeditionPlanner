using ExpeditionPlanner.Models;
using System;

namespace ExpeditionPlanner.Factories {
  public class DiplomaticMissionFactory : MissionFactory {
    public override Mission CreateMission() {
      return new DiplomaticMission();
    }
  }
}