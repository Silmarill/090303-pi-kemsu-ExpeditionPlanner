using System;
using ExpeditionPlanner.Models;
using System.Collections.Generic;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private List<MissionFactory> _factories = new List<MissionFactory>();
    private Random _random = new Random();

    int peopleCount = 42;

    public RandomMissionFactory() {
      _factories.Add(new CargoMissionFactory());
      _factories.Add(new CombatMissionFactory());
      _factories.Add(new DiplomaticMissionFactory());
      _factories.Add(new ExplorationMissionFactory());
      _factories.Add(new RescueMissionFactory(peopleCount));
    }

    public override Mission CreateMission() {
      MissionFactory selectedFactory;
      Mission mission;

      int randomIndex;

      randomIndex = _random.Next(0, _factories.Count);
      selectedFactory = _factories[randomIndex];
      mission = selectedFactory.CreateMission();

      return mission;
    }
  }
}