using ExpeditionPlanner.Models;
using System;
using System.Collections.Generic;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private List<MissionFactory> _factories;
    private Random _random;

    public RandomMissionFactory() {
      _random = new Random();
      _factories = new List<MissionFactory> {
        new ExplorationMissionFactory(),
        new CombatMissionFactory(),
        new CargoMissionFactory(),
        new DiplomaticMissionFactory(),
        new RescueMissionFactory(50)
      };
    }

    public override Mission CreateMission() {
      int randomIndex = _random.Next(_factories.Count);

      return _factories[randomIndex].CreateMission();
    }
  }
}
