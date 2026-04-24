using System;
using ExpeditionPlanner.Models;
using System.Collections.Generic;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private readonly List<MissionFactory> _factories;
    private readonly Random _random = new Random();
    private readonly int _defaultRescueCapacity = 50;

    public RandomMissionFactory() {
      _factories = new List<MissionFactory>();
      _factories.Add(new ExplorationMissionFactory());
      _factories.Add(new CombatMissionFactory());
      _factories.Add(new CargoMissionFactory());
      _factories.Add(new DiplomaticMissionFactory());
      _factories.Add(new RescueMissionFactory(_defaultRescueCapacity));
    }

    public override Mission CreateMission() {
      int randomIndex = _random.Next(_factories.Count);
      return _factories[randomIndex].CreateMission();
    }
  }
}