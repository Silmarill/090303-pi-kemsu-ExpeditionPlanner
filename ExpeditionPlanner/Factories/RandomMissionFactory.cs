using ExpeditionPlanner.Models;
using System;
using System.Collections.Generic;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private List<MissionFactory> _factories;
    private Random _random = new Random();

    private int _defaultRescueCrewCapacity = 50;

    public RandomMissionFactory() {
      _factories = new List<MissionFactory>();

      _factories.Add(new CargoMissionFactory());
      _factories.Add(new CombatMissionFactory());
      _factories.Add(new ExplorationMissionFactory());
      _factories.Add(new RescueMissionFactory(_defaultRescueCrewCapacity));
      _factories.Add(new DiplomaticMissionFactory());
    }

    public override Mission CreateMission() {
      int randomIndex;
      randomIndex = _random.Next(_factories.Count);
      MissionFactory randomFactory = _factories[randomIndex];
      return randomFactory.CreateMission();
    }
  }
}
