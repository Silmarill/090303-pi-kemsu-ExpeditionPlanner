using System;
using ExpeditionPlanner.Models;
using System.Collections.Generic;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private List<MissionFactory> _factories;
    private Random _random;

    public RandomMissionFactory() {
      _random = new Random();
      _factories = new List<MissionFactory>() {
        new CombatMissionFactory(),
        new DiplomaticMissionFactory(),
        new ExplorationMissionFactory(),
        new RescueMissionFactory(150)
      };
    }

    public override Mission CreateMission() {
      int randomIndex = _random.Next(_factories.Count);
      MissionFactory selectedFactory = _factories[randomIndex];
      return selectedFactory.CreateMission();
    }
  }
}