using System;
using System.Collections.Generic;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private readonly List<MissionFactory> _factories;
    private readonly Random _random = new Random();
    private readonly RescueMissionFactory _rescueFacrory;
    private readonly int _maxPeopleCountForRescueMission = 100;
    private readonly int _minCount = 0;

    public RandomMissionFactory() {
      _rescueFacrory = new RescueMissionFactory(
        _random.Next(_minCount, _maxPeopleCountForRescueMission));
      _factories = new List<MissionFactory>() {
        new ExplorationMissionFactory(),
        new CombatMissionFactory(),
        new CargoMissionFactory(),
        new DiplomaticMissionFactory(),
        _rescueFacrory
      };
    }

    public override Mission CreateMission() {
      int randomFactoryIndex;
      randomFactoryIndex = _random.Next(_minCount, _factories.Count);
      Mission newmission = _factories[randomFactoryIndex].CreateMission();
      return newmission;
    }
  }
}
