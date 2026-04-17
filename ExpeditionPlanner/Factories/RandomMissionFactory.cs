using System;
using System.Collections.Generic;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private List<MissionFactory> _factories;
    private Random _random = new Random();

    public RandomMissionFactory() {
      _factories = new List<MissionFactory> {
        new ExplorationMissionFactory(),
        new CombatMissionFactory(),
        new CargoMissionFactory(),
        new DiplomaticMissionFactory(),
        new RescueMissionFactory()
      };
    }

    public override Mission CreateMission() {
      int randomIndex = _random.Next(_factories.Count);
      return _factories[randomIndex].CreateMission();
    }
  }
}

