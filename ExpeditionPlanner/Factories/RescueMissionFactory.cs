using ExpeditionPlanner.Models;
using System;

namespace ExpeditionPlanner.Factories {
  public class RescueMissionFactory : MissionFactory {
    private Random _random = new Random();

    public override Mission CreateMission() {
      int peopleCount = _random.Next(10, 101);
      return new RescueMission(peopleCount);
    }
  }
}
