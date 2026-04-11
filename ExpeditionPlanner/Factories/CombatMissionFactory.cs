using System;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class CombatMissionFactory : MissionFactory {
    public override Mission CreateMission() {
      return new CombatMission();
    }
  }
}
