using System;
using System.Collections.Generic;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private List<MissionFactory> _factories;
    private Random _random;

    public RandomMissionFactory() {
      int NumberOfPeople;
      NumberOfPeople = 200;
      _factories = new List<MissionFactory>();
      _factories.Add(new ExplorationMissionFactory());
      _factories.Add(new CombatMissionFactory());
      _factories.Add(new CargoMissionFactory());
      _factories.Add(new DiplomaticMissionFactory());
      _factories.Add(new RescueMissionFactory(NumberOfPeople));
      _random = new Random();
    }

    public override Mission CreateMission() {
      int factoryIndex;
      factoryIndex = _random.Next(_factories.Count);

      MissionFactory selectedFactory = _factories[factoryIndex];
      Mission newMission = selectedFactory.CreateMission();
      return newMission;
    }
  }
}