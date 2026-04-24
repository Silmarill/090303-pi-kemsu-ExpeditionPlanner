using System;
using System.Collections.Generic;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private const int MinimumFactoryIndex = 0;

    private readonly List<MissionFactory> _availableFactories;
    private readonly Random _randomGenerator;

    public RandomMissionFactory(int rescuePeopleCount) {
      _availableFactories = new List<MissionFactory>
      {
        new ExplorationMissionFactory(),
        new CombatMissionFactory(),
        new CargoMissionFactory(),
        new DiplomaticMissionFactory(),
        new RescueMissionFactory(rescuePeopleCount)
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