using ExpeditionPlanner.Models;
using System;
using System.Collections.Generic;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private readonly List<MissionFactory> _availableFactories;
    private readonly Random _randomGenerator;

    private const int DefaultRescuePeopleCount = 30;
    private const int MinimumFactoryIndex = 0;

    public RandomMissionFactory() {
      _availableFactories = new List<MissionFactory>
      {
                new ExplorationMissionFactory(),
                new CombatMissionFactory(),
                new CargoMissionFactory(),
                new DiplomaticMissionFactory(),
                new RescueMissionFactory(DefaultRescuePeopleCount)
            };

      _randomGenerator = new Random();
    }

    public override Mission CreateMission() {
      int maximumFactoryIndex = _availableFactories.Count;
      int selectedFactoryIndex = _randomGenerator.Next(MinimumFactoryIndex, maximumFactoryIndex);
      MissionFactory selectedFactory = _availableFactories[selectedFactoryIndex];

      return selectedFactory.CreateMission();
    }
  }
}