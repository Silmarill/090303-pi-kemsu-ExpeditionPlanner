using System;
using System.Collections.Generic;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private readonly List<MissionFactory> _availableFactories;
    private readonly Random _randomGenerator;
    private readonly int _rescuePeopleCount;

    public RandomMissionFactory(int rescuePeopleCount) {
      _rescuePeopleCount = rescuePeopleCount;
      _availableFactories = new List<MissionFactory> {
        new ExplorationMissionFactory(),
        new CombatMissionFactory(),
        new CargoMissionFactory(),
        new DiplomaticMissionFactory(),
        new RescueMissionFactory(_rescuePeopleCount)
      };
      _randomGenerator = new Random();
    }

    public override Mission CreateMission() {
      int factoryIndex;
      factoryIndex = _randomGenerator.Next(_availableFactories.Count);
      MissionFactory chosenFactory = _availableFactories[factoryIndex];
      Mission resultMission = chosenFactory.CreateMission();
      return resultMission;
    }
  }
}