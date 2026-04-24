using System;
using System.Collections.Generic;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private readonly List<MissionFactory> _factories;
    private readonly Random _random = new Random();
    private readonly int _defaultRescueCrewCapacity = 50;

    public RandomMissionFactory() {
      _factories = new List<MissionFactory> {
        new CargoMissionFactory(),
        new CombatMissionFactory(),
        new ExplorationMissionFactory(),
        new RescueMissionFactory(_defaultRescueCrewCapacity),
        new DiplomaticMissionFactory()
      };
    }

    public override Mission CreateMission() {
      int randomIndex;
      randomIndex = _random.Next(_factories.Count);
      MissionFactory randomFactory = _factories[randomIndex];
      return randomFactory.CreateMission();
    }
  }
}
