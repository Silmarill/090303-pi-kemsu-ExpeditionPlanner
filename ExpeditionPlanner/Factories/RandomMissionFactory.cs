using ExpeditionPlanner.Models;
using System;
using System.Collections.Generic;

namespace ExpeditionPlanner.Factories {
  public class RandomMissionFactory : MissionFactory {
    public List<MissionFactory> Factories;
    public Random Random = new Random();

    public static int DefaultRescuePeopleCount = 50;

    public RandomMissionFactory() : this(DefaultRescuePeopleCount) { }

    public RandomMissionFactory(int rescuePeopleCount) {
      Factories = new List<MissionFactory>
      {
       new ExplorationMissionFactory(),
       new CombatMissionFactory(),
       new CargoMissionFactory(),
       new DiplomaticMissionFactory(),
       new RescueMissionFactory(rescuePeopleCount)
      };
    }

    public override Mission CreateMission() {
      int index = Random.Next(Factories.Count);
      return Factories[index].CreateMission();
    }
  }
}