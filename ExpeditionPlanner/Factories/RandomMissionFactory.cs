using ExpeditionPlanner.Models;
using System;
using System.Collections.Generic;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private List<MissionFactory> _factories;
    private Random _random;

    private RandomMissionFactory() {
      _random = new Random();

      List<MissionFactory> _factories = new List<MissionFactory>
      {
            new ExplorationMissionFactory(),
            new CombatMissionFactory(),
            new CargoMissionFactory(),
            new DiplomaticMissionFactory(),
            new RescueMissionFactory(50)
      };
    }

    public override Mission CreateMission() {
      int randIndex;
      randIndex = _random.Next(0, _factories.Count);
      return _factories[randIndex].CreateMission();
    }
  }
}
