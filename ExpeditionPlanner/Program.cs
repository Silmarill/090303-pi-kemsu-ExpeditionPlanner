using System;
using System.Collections.Generic;
using ExpeditionPlanner.Factories;
using ExpeditionPlanner.Models;

namespace ExpeditionPlanner {
  internal class Program {
    static void Main() {
      List<MissionFactory> factories = new List<MissionFactory> {
        new RandomMissionFactories()
      };

      Console.WriteLine("=== План миссий на месяц ===\n");

      MissionFactory factory = factories[0];
      Mission mission = factory.CreateMission();

      Console.WriteLine($"Миссия: {mission.Name} (длительность: {mission.Duration} дней)");
      mission.Execute();

      Console.WriteLine(mission.GetReport());
      Console.WriteLine();
    }
  }
}
