using System;
using System.Collections.Generic;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    private readonly List<MissionFactory> _factories;
    private readonly Random _random;
    private readonly int howManyPeopleResc;

    public RandomMissionFactory(int rescPpl) {
      _random = new Random();

      _factories = new List<MissionFactory>
      {
            new ExplorationMissionFactory(),
            new CombatMissionFactory(),
            new CargoMissionFactory(),
            new DiplomaticMissionFactory(),
            new RescueMissionFactory(howManyPeopleResc)
      };
      howManyPeopleResc = rescPpl;
    }

    public override Mission CreateMission() {
      int randIndex;
      randIndex = _random.Next(0, _factories.Count);
      return _factories[randIndex].CreateMission();
    }
  }
}
