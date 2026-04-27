using System;
using System.Collections.Generic;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactories : MissionFactory {
    private List<MissionFactory> _factories = new List<MissionFactory>();
    private Random _random = new Random();

    public RandomMissionFactories() {
      _factories.Add(new CargoMissionFactory());
      _factories.Add(new CombatMissionFactory());
      _factories.Add(new DiplomaticMissionFactory());
      _factories.Add(new ExplorationMissionFactory());
    }

    public override Mission CreateMission() {
      int randomIndex = _random.Next(_factories.Count + 1);

      if (randomIndex == _factories.Count) {
        int peopleCount = _random.Next(10, 101);
        MissionFactory rescueMissionFactory = new RescueMissionFactory(peopleCount);
        Mission rescueMission = rescueMissionFactory.CreateMission();
        return rescueMission;
      }

      MissionFactory randomFactory = _factories[randomIndex];
      Mission newMission = randomFactory.CreateMission();
      return newMission;
    }
  }
}
