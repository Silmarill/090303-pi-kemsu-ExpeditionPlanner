using System;
using ExpeditionPlanner.Models;
using System.Collections.Generic;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private List<MissionFactory> _factories;
    private Random _random;

    RandomMissionFactory() {

    }

    public override Mission CreateMission() {
    }
  }
}