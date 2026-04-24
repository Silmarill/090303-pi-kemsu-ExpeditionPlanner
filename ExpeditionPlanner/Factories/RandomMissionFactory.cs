using System;
using System.Collections.Generic;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private List<MissionFactory> _factories;
    private Random _random = new Random();

    public RandomMissionFactory() {
      int rescueMissionSuccessChance = 50;

      _factories = new List<MissionFactory>();

      _factories.Add(new CargoMissionFactory());
      _factories.Add(new CombatMissionFactory());
      _factories.Add(new ExplorationMissionFactory());
      _factories.Add(new RescueMissionFactory(rescueMissionSuccessChance));
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
