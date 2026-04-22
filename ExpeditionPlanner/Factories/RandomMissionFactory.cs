using ExpeditionPlanner.Models;
using System;
using System.Collections.Generic;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private readonly List<MissionFactory> _factories;
    private readonly Random _random = new Random();

    public RandomMissionFactory() {
      _factories = new List<MissionFactory>
      {
                new ExplorationMissionFactory(),
                new CombatMissionFactory(),
                new CargoMissionFactory(),
                new DiplomaticMissionFactory(),
                new RescueMissionFactory(50)
            };
    }

    public override Mission CreateMission() {
      int index = _random.Next(_factories.Count);
      return _factories[index].CreateMission();
    }
  }
}