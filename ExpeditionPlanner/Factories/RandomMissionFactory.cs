using System;
using System.Collections.Generic;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private const int DefaultRescuePeopleCount = 50;
    private List<MissionFactory> _factories;
    private Random _random;

    public RandomMissionFactory() {
      _random = new Random();
      _factories = new List<MissionFactory> {
        new ExplorationMissionFactory(),
        new CombatMissionFactory(),
        new CargoMissionFactory(),
        new DiplomaticMissionFactory(),
        new RescueMissionFactory(DefaultRescuePeopleCount)
      };
    }

    public override Mission CreateMission() {
      int index = _random.Next(_factories.Count);
      return _factories[index].CreateMission();
    }
  }
}