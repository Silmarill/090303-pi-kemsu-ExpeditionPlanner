using System;
using System.Collections.Generic;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private readonly List<MissionFactory> _factories;
    private readonly Random _random;

    public RandomMissionFactory() {
      _random = new Random();

      int rescueMissionParameter = 50;

      List<MissionFactory> missionFactories = new List<MissionFactory>
      {
        new ExplorationMissionFactory(),
        new CombatMissionFactory(),
        new CargoMissionFactory(),
        new DiplomaticMissionFactory(),
        new RescueMissionFactory(rescueMissionParameter)
      };
      _factories = missionFactories;
    }

    public override Mission CreateMission() {
      int randomIndex;
      randomIndex = _random.Next(_factories.Count);
      return _factories[randomIndex].CreateMission();
    }
  }
}