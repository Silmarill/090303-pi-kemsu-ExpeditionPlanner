using System;
using System.Collections.Generic;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private const int rescueMissionPeopleSave = 50;
    private readonly List<MissionFactory> _factories;
    private readonly Random _random;

    public RandomMissionFactory() {
      _factories = new List<MissionFactory>() {
        new ExplorationMissionFactory(),
        new CombatMissionFactory(),
        new CargoMissionFactory(),
        new DiplomaticMissionFactory(),
        new RescueMissionFactory(rescueMissionPeopleSave)
      };

      _random = new Random();
    }

    public override Mission CreateMission() {
      int randomIndex;
      randomIndex = _random.Next(0, _factories.Count);

      MissionFactory selectedFactory;
      selectedFactory = _factories[randomIndex];

      Mission mission;
      mission = selectedFactory.CreateMission();

      return mission;
    }
  }
}