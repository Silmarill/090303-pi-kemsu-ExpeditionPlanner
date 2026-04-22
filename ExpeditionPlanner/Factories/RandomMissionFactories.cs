using ExpeditionPlanner.Models;
using System;
using System.Collections.Generic;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactories : MissionFactory {
    private List<MissionFactory> _factories = new List<MissionFactory>();
    public Random _random = new Random();
    int randomIndex;

    public RandomMissionFactories() {
      _factories.Add(new CargoMissionFactory());
      _factories.Add(new CombatMissionFactory());
      _factories.Add(new DiplomaticMissionFactory());
      _factories.Add(new ExplorationMissionFactory());
      _factories.Add(new RescueMissionFactory(0));
    }

    public override Mission CreateMission() {
      randomIndex = _random .Next(_factories.Count);
      MissionFactory randomFactory = _factories[randomIndex];
      Mission newMission = randomFactory.CreateMission();
      return newMission;
    }
  }
}

