using System;
using System.Collections.Generic;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private readonly List<MissionFactory> _factories;
    private readonly Random _random = new Random();

    public RandomMissionFactory() {
      _factories = new List<MissionFactory>
      {
                new ExplorationMissionFactory(5),
                new CombatMissionFactory(12),
                new CargoMissionFactory(500),
                new DiplomaticMissionFactory(),
                new RescueMissionFactory(100)
            };
    }

    public override Mission CreateMission() {
      int index = _random.Next(_factories.Count);
      return _factories[index].CreateMission();
    }
  }
}