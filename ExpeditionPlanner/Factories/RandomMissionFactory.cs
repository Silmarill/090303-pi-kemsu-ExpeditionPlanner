using System;
using System.Collections.Generic;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private List<MissionFactory> _factories;
    private Random _random;
    private const int rescueMissionPeopleSave = 50;

    public RandomMissionFactory() {
      _factories = new List<MissionFactory>();
      _factories.Add(new ExplorationMissionFactory());
      _factories.Add(new CombatMissionFactory());
      _factories.Add(new CargoMissionFactory());
      _factories.Add(new DiplomaticMissionFactory());
      _factories.Add(new RescueMissionFactory(rescueMissionPeopleSave));

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